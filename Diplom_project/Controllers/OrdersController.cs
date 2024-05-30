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

            //return Ok(await this.ordersService.GetOkRepo());

            return Ok(await DbCollections.OrdersCollection.Find("{}").ToListAsync());
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
            
            return Ok("put ok");
        }
    }

    
}