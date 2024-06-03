using Diplom_project.Classes;
using MongoDB.Driver;

namespace Diplom_project.Repositories
{
    public class FulfilledOrdersRepository
    {
        public async void AddOrderToFulfilled(OnlineOrder onlineOrder)
        {
            await DbCollections.OrdersFulfilledCollection.InsertOneAsync(onlineOrder);
        }
    }

}
