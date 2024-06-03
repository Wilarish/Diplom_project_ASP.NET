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



namespace FlowerShop.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderService ordersService;

        public OrdersController(OrderService _ordersService)
        {
            this.ordersService = _ordersService;
        }
       
       

        [HttpGet]
        public async Task<IActionResult> GetUnfulfilledOrders()
        {
            // Получение всех текущих (невыполненных в данный момент) заказов цветов

            var orders = await ordersService.GetAllOrders();

            return Ok(JsonConvert.SerializeObject(orders, Formatting.Indented));
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrderById(string orderId)
        {
            //Get one unfulfilled order

            var order = await this.ordersService.GetOrderById(orderId);

            if (order != null)
            {
                return Ok(JsonConvert.SerializeObject(order, Formatting.Indented));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddNewOrder([FromBody] OnlineOrderCreate order)
        {
            // creating new onlineOrder

            var OrderView = await this.ordersService.CreateOrder(order);

            return Ok(JsonConvert.SerializeObject(OrderView, Formatting.Indented));

        }

        [HttpPost("{orderId}")]
        public async Task<IActionResult> SaveFulfilledOrder(string orderId)
        {
            // Сохранение деталей выполненного заказа в другую коллекцию

            bool fulfilled = await this.ordersService.FulfilledOrder(orderId);

            if (fulfilled)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{orderId}")]
        public async Task<IActionResult> DeleteOrder(string orderId)
        {
            // Удаление (при отмене) текущего заказа

            bool deleteResult = await this.ordersService.DeleteOrderById(orderId);

            if (deleteResult)
            {
                return NoContent();
            }
            else 
            { 
                return NotFound();
            }

            
        }

        

        [HttpDelete("deleteAll")]
        public async Task<IActionResult> DeleteAllOrders()
        {
            // deleting collection of unfulfilled orders

            this.ordersService.DeleteAllOrders();

            return NoContent();
        }
    }

    
}