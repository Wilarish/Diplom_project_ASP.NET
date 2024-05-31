using Diplom_project.Classes;
using Diplom_project.Repositories;
using Diplom_project.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;

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

            return Ok(await this.ordersService.GetAllOrders());
        }

        [HttpPost]
        public IActionResult AddNewOrder([FromBody] OnlineOrderCreate order)
        {
            // Добавление нового заказа

            return NoContent();
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
        public async Task<IActionResult> DeleteAllOrders(Guid orderId)
        {
            // Зачистка бд

            DbCollections.OrdersCollection.DeleteMany("{}");

            return NoContent();
        }
    }

    
}