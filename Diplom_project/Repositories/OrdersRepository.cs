using Diplom_project.Classes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace Diplom_project.Repositories
{
    public class OrdersRepository
    {
        public async Task<List<CustomerInfo>> GetOkRepo()
        {
            return await DbCollections.OrdersCollection.Find("{}").ToListAsync();
        }

    }
}
