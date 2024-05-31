using Diplom_project.Classes;
using Diplom_project.Repositories;
using MongoDB.Bson;

namespace Diplom_project.Services
{
    public class OrderService
    {
        private readonly OrdersRepository ordersRepository;
        private readonly FulfilledOrdersRepository fulfilledOrdersRepository;

        public OrderService(OrdersRepository _ordersRepository, FulfilledOrdersRepository _fulfilledOrdersRepository)
        {
            ordersRepository = _ordersRepository;
            fulfilledOrdersRepository = _fulfilledOrdersRepository;
        }
       
        public async Task<List<OnlineOrder>> GetAllOrders()
        {
            return await this.ordersRepository.GetAllOrders();
        }

        public async Task<bool> DeleteOrderById(string orderId)
        {
            return await this.ordersRepository.DeleteOrderById(new ObjectId(orderId));
        }
        public async Task<bool> FulfilledOrder(string orderId)
        {
            var order = await this.ordersRepository.ReturnOrderById(new ObjectId(orderId));
            if (order.Count == 0) 
            {
                return false;
            }
            order[0].IsFulfilled = true;
            order[0].CompletedAt = DateTime.Now;

            this.fulfilledOrdersRepository.AddOrderToFulfilled(order[0]);

            return await this.ordersRepository.DeleteOrderById(new ObjectId(orderId));

        }
    }
}
