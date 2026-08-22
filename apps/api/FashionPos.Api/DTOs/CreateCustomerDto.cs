using System.ComponentModel.DataAnnotations;

namespace FashionPos.Api.DTOs
{
    public class CreateCustomerDto
    {
        [Required(ErrorMessage = "Họ tên khách hàng không được để trống")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        public string PhoneNumber { get; set; } = string.Empty;

        public short Gender { get; set; } = 1; // 1: Nam, 0: Nữ

        public string? Address { get; set; }
    }
}
