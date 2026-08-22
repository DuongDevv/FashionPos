using FashionPos.Api.Data;
using FashionPos.Api.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FashionPos.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly FashionPosDbContext _db;

        public CustomersController(FashionPosDbContext db)
        {
            _db = db;
        }

        // GET: api/v1/customers
        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _db.Customers
                .OrderByDescending(c => c.Id)
                .Select(c => new
                {
                    c.Id,
                    c.FullName,
                    c.PhoneNumber,
                    c.TotalSpent,
                    c.LoyaltyPoints,
                    MembershipTier = c.MembershipTier.ToString()
                })
                .ToListAsync();

            return Ok(new
            {
                success = true,
                statusCode = 200,
                total = customers.Count,
                data = customers
            });
        }

        // GET: api/v1/customers/phone/{phone}
        // Endpoint tra cứu nhanh khách hàng theo Số Điện Thoại cho máy POS
        [HttpGet("phone/{phone}")]
        public async Task<IActionResult> GetCustomerByPhone(string phone)
        {
            var customer = await _db.Customers
                .FirstOrDefaultAsync(c => c.PhoneNumber != null && c.PhoneNumber.Contains(phone.Trim()));

            if (customer == null)
            {
                return NotFound(new
                {
                    success = false,
                    statusCode = 404,
                    message = $"Không tìm thấy khách hàng nào có số điện thoại: {phone}"
                });
            }

            return Ok(new
            {
                success = true,
                statusCode = 200,
                data = new
                {
                    customerId = customer.Id,
                    fullName = customer.FullName,
                    phoneNumber = customer.PhoneNumber,
                    totalSpent = customer.TotalSpent,
                    loyaltyPoints = customer.LoyaltyPoints,
                    membershipTier = customer.MembershipTier.ToString()
                }
            });
        }

        // POST: api/v1/customers
        // Endpoint đăng ký khách hàng mới nhanh tại quầy POS
        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    success = false,
                    statusCode = 400,
                    message = "Dữ liệu khách hàng không hợp lệ!"
                });
            }

            // Check duplicate phone number
            var existingPhone = await _db.Customers
                .AnyAsync(c => c.PhoneNumber == dto.PhoneNumber.Trim());

            if (existingPhone)
            {
                return Conflict(new
                {
                    success = false,
                    statusCode = 409,
                    message = $"Số điện thoại '{dto.PhoneNumber}' đã được đăng ký thành viên!"
                });
            }

            var customer = new Customer
            {
                FullName = dto.FullName.Trim(),
                PhoneNumber = dto.PhoneNumber.Trim(),
                TotalSpent = 0,
                LoyaltyPoints = 0,
                MembershipTier = MembershipTierEnum.BRONZE
            };

            _db.Customers.Add(customer);
            await _db.SaveChangesAsync();

            return Created(string.Empty, new
            {
                success = true,
                statusCode = 201,
                message = "Đăng ký thành viên mới thành công!",
                data = new
                {
                    customerId = customer.Id,
                    fullName = customer.FullName,
                    phoneNumber = customer.PhoneNumber,
                    totalSpent = customer.TotalSpent,
                    loyaltyPoints = customer.LoyaltyPoints,
                    membershipTier = customer.MembershipTier.ToString()
                }
            });
        }
    }
}
