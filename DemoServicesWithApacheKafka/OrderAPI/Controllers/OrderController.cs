using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderAPI.OrderServices;
using Shared;

namespace OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(IOrderService orderService): ControllerBase
    {
        [HttpGet("start-consuming-service")]
        public async Task<IActionResult> StartService()
        {
            await orderService.StartConsumingService();
            return NoContent();
        }

        [HttpGet("get-product")]
        public IActionResult GetProducts()
        {
            var products = orderService.GetProducts();
            return Ok(products);
        }

        [HttpPost("add-order")]
        public IActionResult AddOrder(Order order)
        {
            orderService.AddOrder(order);
            return Ok("Order placed");
        }

        [HttpGet("order-summary")]
        public IActionResult GetOrdersSummary1() => Ok(orderService.GetOrdersSummary());

    };
}
