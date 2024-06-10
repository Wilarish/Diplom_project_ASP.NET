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
        
       
        public async Task<List<OnlineOrderView>> GetAllOrders()
        {
            return await this.ordersRepository.GetAllViewOrders();
        }

        public async Task<OnlineOrderView?> GetOrderById(string orderId)
        {
            var ordersList = await this.ordersRepository.GetViewOrderById(new ObjectId(orderId));
            if (ordersList.Count == 0)
            {
                return null;
            }
            return ordersList[0];

        }

        public async Task<List<OnlineOrderView>> GetOrdersByPhoneNumber(string phoneNumber)
        {
            var ordersList = await this.ordersRepository.GetViewOrdersByPhoneNumber(phoneNumber);
            if (ordersList.Count == 0)
            {
                return null;
            }
            return ordersList;

        }
        public OnlineOrderView CreateOrder(OnlineOrderCreate orderCreate)
        {
            int totalSum = 0;
            foreach (BouquetType bouquets in orderCreate.BouquetTypes)
            {
                totalSum += bouquets.Cost * bouquets.Count;
            }
            var orderDb = new OnlineOrder(orderCreate.CustomerInfo, orderCreate.BouquetTypes, false, totalSum);

            this.ordersRepository.SaveNewOrder(orderDb);

            return new OnlineOrderView(orderDb.OrderId, orderDb.CustomerInfo, orderDb.BouquetType, totalSum, orderDb.CreatedAt);
        }

        public async Task<bool> DeleteOrderById(string orderId)
        {
            return await this.ordersRepository.DeleteOrderById(new ObjectId(orderId));
        }
        public async Task<bool> FulfilledOrder(string orderId)
        {
            var order = await this.ordersRepository.GetOrderById(new ObjectId(orderId));
            if (order.Count == 0) 
            {
                return false;  
            }
            order[0].IsFulfilled = true;
            order[0].CompletedAt = DateTime.Now;

            this.fulfilledOrdersRepository.AddOrderToFulfilled(order[0]);

            return await this.ordersRepository.DeleteOrderById(new ObjectId(orderId));

        }
        public void DeleteAllOrders()
        {
            this.ordersRepository.DeleteAllOrders();
        }


    }
}
