using FashionPos.Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FashionPos.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class VariantsController : ControllerBase
    {
        private readonly FashionPosDbContext _db;

        public VariantsController(FashionPosDbContext db)
        {
            _db = db;
        }

        // GET: api/v1/variants/sku/{sku}
        // Endpoint quét mã vạch SKU tốc độ cao cho quầy POS
        [HttpGet("sku/{sku}")]
        public async Task<IActionResult> GetVariantBySku(string sku)
        {
            var variant = await _db.ProductVariants
                .FirstOrDefaultAsync(v => v.Sku.ToLower() == sku.ToLower());

            if (variant == null)
            {
                return NotFound(new
                {
                    success = false,
                    statusCode = 404,
                    message = $"Không tìm thấy sản phẩm có mã vạch SKU: {sku}"
                });
            }

            var product = await _db.Products.FindAsync(variant.ProductId);

            return Ok(new
            {
                success = true,
                statusCode = 200,
                data = new
                {
                    variantId = variant.Id,
                    productId = variant.ProductId,
                    productName = product?.Name ?? "Sản phẩm NQD",
                    sku = variant.Sku,
                    size = variant.Size,
                    color = variant.Color,
                    price = variant.Price,
                    stockQuantity = variant.StockQuantity
                }
            });
        }
    }
}
