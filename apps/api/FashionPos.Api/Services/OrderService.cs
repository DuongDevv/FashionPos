using FashionPos.Api.Data;
using FashionPos.Api.DTOs;
using Microsoft.EntityFrameworkCore;

namespace FashionPos.Api.Services
{
    public interface IOrderService
    {
        Task<object> CreatePosOrderAsync(CreateOrderDto dto);
    }

    public class OrderService : IOrderService
    {
        private readonly FashionPosDbContext _db;
        private readonly ILogger<OrderService> _logger;

        public OrderService(FashionPosDbContext db, ILogger<OrderService> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task<object> CreatePosOrderAsync(CreateOrderDto dto)
        {
            if (dto.Items == null || !dto.Items.Any())
            {
                throw new InvalidOperationException("Đơn hàng phải chứa ít nhất 1 sản phẩm!");
            }

            // Parse Enum types
            Enum.TryParse<PaymentMethodEnum>(dto.PaymentMethod, true, out var paymentMethod);
            Enum.TryParse<DiscountTypeEnum>(dto.DiscountType, true, out var discountType);

            // Bắt đầu EF Core Database Transaction (ACID)
            using var transaction = await _db.Database.BeginTransactionAsync();

            try
            {
                decimal totalItemsAmount = 0;

                // 1. Kiểm tra tồn kho & Tính tổng tiền các món
                foreach (var item in dto.Items)
                {
                    var variant = await _db.ProductVariants
                        .FirstOrDefaultAsync(v => v.Id == item.VariantId);

                    if (variant == null)
                    {
                        throw new KeyNotFoundException($"Không tìm thấy sản phẩm variant_id = {item.VariantId}");
                    }

                    if (variant.StockQuantity < item.Quantity)
                    {
                        throw new InvalidOperationException(
                            $"Biến thể SKU '{variant.Sku}' không đủ tồn kho! (Tồn: {variant.StockQuantity}, Yêu cầu: {item.Quantity})");
                    }

                    // Trừ tồn kho an toàn
                    variant.StockQuantity -= item.Quantity;
                    variant.Version += 1;

                    totalItemsAmount += item.Quantity * item.UnitPrice;
                }

                // 2. Tính giảm giá & số tiền cuối cùng
                decimal discountAmount = 0;
                if (discountType == DiscountTypeEnum.PERCENT)
                {
                    discountAmount = totalItemsAmount * (dto.DiscountValue / 100m);
                }
                else
                {
                    discountAmount = dto.DiscountValue;
                }

                decimal finalAmount = Math.Max(0, totalItemsAmount - discountAmount);

                if (dto.PaidAmount < finalAmount)
                {
                    throw new InvalidOperationException($"Số tiền khách đưa ({dto.PaidAmount:N0}đ) nhỏ hơn tiền cần trả ({finalAmount:N0}đ)!");
                }

                // 3. Tích điểm khách hàng (10.000đ = 1 điểm)
                int earnedPoints = (int)(finalAmount / 10000m);

                // 4. Tạo Master Order
                string orderCode = $"HD{DateTime.UtcNow:yyMMddHHmmss}{Random.Shared.Next(10, 99)}";
                var order = new Order
                {
                    OrderCode = orderCode,
                    CustomerId = dto.CustomerId,
                    EmployeeId = dto.EmployeeId,
                    TotalItemsAmount = totalItemsAmount,
                    DiscountType = discountType,
                    DiscountValue = dto.DiscountValue,
                    FinalAmount = finalAmount,
                    PaidAmount = dto.PaidAmount,
                    PaymentMethod = paymentMethod,
                    Status = OrderStatusEnum.COMPLETED,
                    CreatedAt = DateTime.UtcNow
                };

                _db.Orders.Add(order);
                await _db.SaveChangesAsync();

                // 5. Thêm Chi Tiết Hóa Đơn (Order Details)
                foreach (var item in dto.Items)
                {
                    _db.OrderDetails.Add(new OrderDetail
                    {
                        OrderId = order.Id,
                        VariantId = item.VariantId,
                        Quantity = item.Quantity,
                        UnitPrice = item.UnitPrice
                    });
                }

                // 6. Cập nhật Điểm & Hạng Khách Hàng (nếu có customer_id)
                if (dto.CustomerId.HasValue)
                {
                    var customer = await _db.Customers.FindAsync(dto.CustomerId.Value);
                    if (customer != null)
                    {
                        customer.TotalSpent += finalAmount;
                        customer.LoyaltyPoints += earnedPoints;

                        // Nâng hạng tự động: Đồng -> Bạc -> Vàng -> Đen
                        if (customer.LoyaltyPoints >= 300) customer.MembershipTier = MembershipTierEnum.BLACK;
                        else if (customer.LoyaltyPoints >= 200) customer.MembershipTier = MembershipTierEnum.GOLD;
                        else if (customer.LoyaltyPoints >= 100) customer.MembershipTier = MembershipTierEnum.SILVER;
                        else customer.MembershipTier = MembershipTierEnum.BRONZE;
                    }
                }

                await _db.SaveChangesAsync();

                // Commit Transaction thành công
                await transaction.CommitAsync();

                _logger.LogInformation("Tạo đơn hàng POS {OrderCode} thành công. Tổng tiền: {FinalAmount:N0}đ", orderCode, finalAmount);

                return new
                {
                    success = true,
                    statusCode = 201,
                    orderId = order.Id,
                    orderCode = order.OrderCode,
                    totalItemsAmount,
                    finalAmount,
                    paidAmount = dto.PaidAmount,
                    changeAmount = dto.PaidAmount - finalAmount,
                    earnedPoints
                };
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _logger.LogError(ex, "Lỗi khi tạo đơn hàng POS: {Message}", ex.Message);
                throw;
            }
        }
    }
}
