using Diplom_project.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Diplom_project.Controllers
{
    [Route("orders-history")]
    [ApiController]
    public class OrdersFulfilledController : ControllerBase
    {
        private readonly OrderFulfilledService fulfilledOrdersService;

        public OrdersFulfilledController(OrderFulfilledService _ordersService)
        {
            fulfilledOrdersService = _ordersService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFulfilledOrders()
        {

            var orders = await fulfilledOrdersService.GetAllOrders();

            return Ok(JsonConvert.SerializeObject(orders, Formatting.Indented));
        }

        [HttpGet("phone-number/{phoneNumber}")]
        public async Task<IActionResult> GetOrdersByPhoneNumber(
            [StringLength(15, MinimumLength = 10, ErrorMessage = "it must be a phoneNumber")]
            string phoneNumber)
        {
            var orders = await fulfilledOrdersService.GetOrdersByPhoneNumber(phoneNumber);

            if (orders == null)
            {
                return NotFound();

            }
            return Ok(JsonConvert.SerializeObject(orders, Formatting.Indented));
        }
    }
}
