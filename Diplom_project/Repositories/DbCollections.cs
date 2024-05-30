using Diplom_project.Classes;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Diplom_project.Repositories
{
    public class DbCollections
    {
        public static IMongoCollection<CustomerInfo> OrdersCollection { get; set; }
    }
}
