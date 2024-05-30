using Diplom_project.Repositories;
using MongoDB.Bson;

namespace Diplom_project.Services
{
    public class OrderService
    {
        private readonly OrdersRepository ordersRepository;

        public OrderService(OrdersRepository _ordersRepository)
        {
            ordersRepository = _ordersRepository;
        }
        public string GetOkService()
        {
            return "ok from service";
        }
        //public async Task<List<BsonDocument>> GetOkRepo()
        //{
        //    var ordersDb = await this.ordersRepository.GetOkRepo();

        //    var ordersParsed = [];
        //    foreach (var order in ordersDb)
        //    {
        //        ordersParsed.Add(order.ToJson());
        //    }
            
        //}
    }
}
