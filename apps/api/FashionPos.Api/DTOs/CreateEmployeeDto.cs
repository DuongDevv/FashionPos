using System.ComponentModel.DataAnnotations;

namespace FashionPos.Api.DTOs
{
    public class CreateEmployeeDto
    {
        [Required(ErrorMessage = "Họ tên nhân viên không được để trống")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Tên đăng nhập không được để trống")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [MinLength(6, ErrorMessage = "Mật khẩu phải có ít nhất 6 ký tự")]
        public string Password { get; set; } = string.Empty;

        [Required]
        public string Role { get; set; } = "CASHIER"; // SUPER_MANAGER, STORE_MANAGER, CASHIER, WAREHOUSE_STAFF

        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
    }
}
