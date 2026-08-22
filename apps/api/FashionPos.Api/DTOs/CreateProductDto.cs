using System.ComponentModel.DataAnnotations;

namespace FashionPos.Api.DTOs
{
    public class CreateProductDto
    {
        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int CategoryId { get; set; } = 1;

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Giá sản phẩm phải lớn hơn hoặc bằng 0")]
        public decimal BasePrice { get; set; }

        [Required(ErrorMessage = "Mã SKU không được để trống")]
        public string Sku { get; set; } = string.Empty;

        [Required]
        public string Size { get; set; } = "M";

        [Required]
        public string Color { get; set; } = "Đen";

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Số lượng tồn kho phải lớn hơn hoặc bằng 0")]
        public int StockQuantity { get; set; } = 10;
    }
}
