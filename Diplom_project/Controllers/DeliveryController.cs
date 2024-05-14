using Diplom_project.Classes;
using Diplom_project.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace FlowerShop.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderService ordersService = new OrderService();
       
       

        [HttpGet]
        public IActionResult GetUnfulfilledOrders()
        {
            // Получение всех текущих (невыполненных в данный момент) заказов цветов

            return Ok(this.ordersService.GetOk());
        }

        [HttpPost]
        public IActionResult AddNewOrder([FromBody] OnlineOrderCreate order)
        {
            // Добавление нового заказа

            return NoContent();
        }

        [HttpDelete("{orderId}")]
        public IActionResult DeleteOrder(Guid orderId)
        {
            // Удаление текущего заказа
            
            return NoContent();
        }

        [HttpPut("{orderId}")]
        public IActionResult SaveFulfilledOrder(string orderId)
        {
            // Сохранение деталей выполненного заказа
            
            return NoContent();
        }
    }

    
}