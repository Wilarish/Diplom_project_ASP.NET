using Diplom_project.Classes;
using Diplom_project.Repositories;
using Diplom_project.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace FlowerShop.Controllers
{
    [Route("orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderService ordersService;

        public OrdersController(OrderService _ordersService)
        {
            ordersService = _ordersService;
        }
       
       

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {

            var orders = await ordersService.GetAllOrders();

            return Ok(JsonConvert.SerializeObject(orders, Formatting.Indented));
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrderById(
            [StringLength(24, MinimumLength = 24, ErrorMessage = "orderId length must be 24 symbols")]
            string orderId)
        {
            var order = await this.ordersService.GetOrderById(orderId);

            if (order == null)
            {
                return NotFound();
                
            }
            return Ok(JsonConvert.SerializeObject(order, Formatting.Indented));
        }

        [HttpGet("phone-number/{phoneNumber}")]
        public async Task<IActionResult> GetOrdersByPhoneNumber(string phoneNumber)
        {
            var orders = await ordersService.GetOrdersByPhoneNumber(phoneNumber);

            if (orders == null)
            {
                return NotFound();
                
            }
            return Ok(JsonConvert.SerializeObject(orders, Formatting.Indented));
        }

        [HttpPost]
        public async Task<IActionResult> AddNewOrder([FromBody] OnlineOrderCreate order)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var OrderView = this.ordersService.CreateOrder(order);

            return Ok(JsonConvert.SerializeObject(OrderView, Formatting.Indented));

        }

        [HttpPost("{orderId}")]
        public async Task<IActionResult> SaveFulfilledOrder(string orderId)
        {

            bool fulfilled = await this.ordersService.FulfilledOrder(orderId);

            if (!fulfilled)
            {
                return NotFound();               
            }
            return NoContent();
        }

        [HttpDelete("{orderId}")]
        public async Task<IActionResult> DeleteOrder(string orderId)
        {

            bool deleteResult = await this.ordersService.DeleteOrderById(orderId);

            if (!deleteResult)
            {
                return NotFound();  
            }
            return NoContent();


        }
        [HttpDelete("deleteAll")]
        public async Task<IActionResult> DeleteAllOrders()
        {
 

            this.ordersService.DeleteAllOrders();

            return NoContent();
        }
    }

    
}