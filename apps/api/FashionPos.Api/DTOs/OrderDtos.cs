using System.ComponentModel.DataAnnotations;

namespace FashionPos.Api.DTOs
{
    public class CreateOrderDto
    {
        public int? CustomerId { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        public string DiscountType { get; set; } = "PERCENT";

        public decimal DiscountValue { get; set; } = 0;

        [Required]
        public string PaymentMethod { get; set; } = "CASH";

        [Required]
        public decimal PaidAmount { get; set; }

        public string? Notes { get; set; }

        [Required]
        public List<OrderItemDto> Items { get; set; } = new();
    }

    public class OrderItemDto
    {
        [Required]
        public int VariantId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Số lượng phải lớn hơn 0")]
        public int Quantity { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal UnitPrice { get; set; }
    }

    public class LoginDto
    {
        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
