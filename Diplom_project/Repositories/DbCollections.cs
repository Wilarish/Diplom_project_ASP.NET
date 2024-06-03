using Diplom_project.Classes;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Diplom_project.Repositories
{
    public class DbCollections
    {
        public static IMongoCollection<OnlineOrder>? OrdersCollection { get; set; }
        public static IMongoCollection<OnlineOrder>? OrdersFulfilledCollection { get; set; }

        public static void DbConnection()
        {

            string mongoUrl = "mongodb://localhost:27017";

            //string mongoUrl = Environment.GetEnvironmentVariable("MONGO_URI");

            MongoClient client = new MongoClient(mongoUrl);
            IMongoDatabase db = client.GetDatabase("Diplom");

            OrdersCollection = db.GetCollection<OnlineOrder>("Orders");
            OrdersFulfilledCollection = db.GetCollection<OnlineOrder>("FulfilledOrders");
        }
    }
}
