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

        public async Task<List<OnlineOrderView>> GetAllViewOrders()
        {
            var projection = Builders<OnlineOrder>.Projection.Exclude("CompletedAt").Exclude("IsFulfilled");
            return await DbCollections.OrdersFulfilledCollection
                .Find("{}")
                .Project<OnlineOrderView>(projection)
                .ToListAsync();
        }
        public async Task<List<OnlineOrderView>> GetViewOrdersByPhoneNumber(string phoneNumber)
        {
            var filter = Builders<OnlineOrder>.Filter.Eq("CustomerInfo.PhoneNumber", phoneNumber);
            var projection = Builders<OnlineOrder>.Projection.Exclude("CompletedAt").Exclude("IsFulfilled");
            return await DbCollections.OrdersFulfilledCollection
                .Find(filter)
                .Project<OnlineOrderView>(projection)
                .ToListAsync();
        }
    }

}
