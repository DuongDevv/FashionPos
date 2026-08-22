using FashionPos.Api.Data;
using FashionPos.Api.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace FashionPos.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly FashionPosDbContext _db;

        public ProductsController(FashionPosDbContext db)
        {
            _db = db;
        }

        // GET: api/v1/products
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _db.Products
                .Where(p => p.IsActive)
                .OrderByDescending(p => p.Id)
                .Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.Slug,
                    p.BasePrice,
                    p.IsActive
                })
                .ToListAsync();

            return Ok(new
            {
                success = true,
                statusCode = 200,
                total = products.Count,
                data = products
            });
        }

        // POST: api/v1/products
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    success = false,
                    statusCode = 400,
                    message = "Dữ liệu sản phẩm không hợp lệ!"
                });
            }

            // Check if SKU exists
            var existingSku = await _db.ProductVariants.AnyAsync(v => v.Sku.ToLower() == dto.Sku.ToLower());
            if (existingSku)
            {
                return Conflict(new
                {
                    success = false,
                    statusCode = 409,
                    message = $"Mã SKU '{dto.Sku}' đã tồn tại trong hệ thống!"
                });
            }

            // Generate slug
            string slug = Regex.Replace(dto.Name.ToLower(), @"[^a-z0-9\s-]", "");
            slug = Regex.Replace(slug, @"\s+", "-").Trim('-');
            slug = $"{slug}-{Random.Shared.Next(100, 999)}";

            using var transaction = await _db.Database.BeginTransactionAsync();

            try
            {
                // 1. Create Product Master
                var product = new Product
                {
                    CategoryId = dto.CategoryId,
                    Name = dto.Name,
                    Slug = slug,
                    BasePrice = dto.BasePrice,
                    IsActive = true
                };

                _db.Products.Add(product);
                await _db.SaveChangesAsync();

                // 2. Create Initial Variant
                var variant = new ProductVariant
                {
                    ProductId = product.Id,
                    Sku = dto.Sku.ToUpper(),
                    Size = dto.Size,
                    Color = dto.Color,
                    Price = dto.BasePrice,
                    StockQuantity = dto.StockQuantity,
                    Version = 0
                };

                _db.ProductVariants.Add(variant);
                await _db.SaveChangesAsync();

                await transaction.CommitAsync();

                return Created(string.Empty, new
                {
                    success = true,
                    statusCode = 201,
                    message = "Thêm sản phẩm mới thành công!",
                    data = new
                    {
                        productId = product.Id,
                        name = product.Name,
                        slug = product.Slug,
                        basePrice = product.BasePrice,
                        sku = variant.Sku,
                        stockQuantity = variant.StockQuantity
                    }
                });
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return StatusCode(500, new
                {
                    success = false,
                    statusCode = 500,
                    message = $"Lỗi hệ thống: {ex.Message}"
                });
            }
        }

        // GET: api/v1/products/system-settings
        [HttpGet("system-settings")]
        public async Task<IActionResult> GetSystemSettings()
        {
            var settings = await _db.SystemSettings.ToListAsync();
            return Ok(new
            {
                success = true,
                statusCode = 200,
                data = settings
            });
        }
    }
}
