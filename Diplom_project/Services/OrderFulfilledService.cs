using Diplom_project.Classes;
using Diplom_project.Repositories;

namespace Diplom_project.Services
{
    public class OrderFulfilledService
    {
        private readonly FulfilledOrdersRepository fulfilledOrdersRepository;

        public OrderFulfilledService( FulfilledOrdersRepository _fulfilledOrdersRepository)
        {
            fulfilledOrdersRepository = _fulfilledOrdersRepository;
        }

        public async Task<List<OnlineOrderView>> GetAllOrders()
        {
            return await this.fulfilledOrdersRepository.GetAllViewOrders();
        }

        public async Task<List<OnlineOrderView>> GetOrdersByPhoneNumber(string phoneNumber)
        {
            var ordersList = await this.fulfilledOrdersRepository.GetViewOrdersByPhoneNumber(phoneNumber);
            if (ordersList.Count == 0)
            {
                return null;
            }
            return ordersList;

        }
    }
}
