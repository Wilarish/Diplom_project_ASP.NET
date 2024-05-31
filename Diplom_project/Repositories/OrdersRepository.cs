using Diplom_project.Classes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace Diplom_project.Repositories
{
    public class OrdersRepository
    {
        public async Task<List<OnlineOrder>> GetAllOrders()
        {
            return await DbCollections.OrdersCollection.Find("{}").ToListAsync();
        }
        public async Task<bool> DeleteOrderById(ObjectId odrerId)
        {
            var result = await DbCollections.OrdersCollection.DeleteOneAsync(Builders<OnlineOrder>.Filter.Eq("_id", odrerId));
            return result.DeletedCount > 0;
        }

        public async Task<List<OnlineOrder>> ReturnOrderById(ObjectId orderId)
        {
            return await DbCollections.OrdersCollection.Find(Builders<OnlineOrder>.Filter.Eq("_id", orderId)).ToListAsync();
        }
    }
}
