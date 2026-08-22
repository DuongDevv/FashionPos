using FashionPos.Api.DTOs;
using FashionPos.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace FashionPos.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // POST: api/v1/orders
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto dto)
        {
            try
            {
                var result = await _orderService.CreatePosOrderAsync(dto);
                return Created(string.Empty, result);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new
                {
                    success = false,
                    statusCode = 409,
                    error = "BUSINESS_RULE_VIOLATION",
                    message = ex.Message
                });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new
                {
                    success = false,
                    statusCode = 404,
                    error = "RESOURCE_NOT_FOUND",
                    message = ex.Message
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    statusCode = 500,
                    error = "INTERNAL_SERVER_ERROR",
                    message = ex.Message
                });
            }
        }
    }
}
