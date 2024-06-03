using Diplom_project.Classes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace Diplom_project.Repositories
{
    public class OrdersRepository
    {
        public async Task<List<OnlineOrderView>> GetAllViewOrders()
        {
            var projection = Builders<OnlineOrder>.Projection.Exclude("CompletedAt").Exclude("IsFulfilled");
            return await DbCollections.OrdersCollection
                .Find("{}")
                .Project<OnlineOrderView>(projection)
                .ToListAsync();
        }
        public async Task<List<OnlineOrderView>> GetViewOrdersByPhoneNumber(string phoneNumber)
        {
            var filter = Builders<OnlineOrder>.Filter.Eq("CustomerInfo.PhoneNumber", phoneNumber);
            var projection = Builders<OnlineOrder>.Projection.Exclude("CompletedAt").Exclude("IsFulfilled");
            return await DbCollections.OrdersCollection
                .Find(filter)
                .Project<OnlineOrderView>(projection)
                .ToListAsync();
        }
        public async Task<List<OnlineOrderView>> GetViewOrderById(ObjectId orderId)
        {
            var filter = Builders<OnlineOrder>.Filter.Eq("_id", orderId);
            var projection = Builders<OnlineOrder>.Projection.Exclude("CompletedAt").Exclude("IsFulfilled");
            return await DbCollections.OrdersCollection
                .Find(filter)
                .Project<OnlineOrderView>(projection)
                .ToListAsync();
        }
        public async Task<List<OnlineOrder>> GetOrderById(ObjectId orderId)
        {
            var filter = Builders<OnlineOrder>.Filter.Eq("_id", orderId);
            return await DbCollections.OrdersCollection
                .Find(filter)
                .ToListAsync();
        }
        public async void CreateNewOrder(OnlineOrder order)
        {
            await DbCollections.OrdersCollection.InsertOneAsync(order);
        }
        public async Task<bool> DeleteOrderById(ObjectId orderId)
        {
            var result = await DbCollections.OrdersCollection.DeleteOneAsync(Builders<OnlineOrder>.Filter.Eq("_id", orderId));
            return result.DeletedCount > 0;
        }
        public async void DeleteAllOrders()
        {
            await DbCollections.OrdersCollection.DeleteManyAsync("{}");
        }
    }
}
