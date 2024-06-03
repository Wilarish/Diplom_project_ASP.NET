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
            //string mongoUrl = "mongodb+srv://tararammmm2004:w5iGTWlkB8HFRjes@cluster0.vwzbeey.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";

            string mongoUrl = "mongodb://localhost:27017";

            MongoClient client = new MongoClient(mongoUrl);
            IMongoDatabase db = client.GetDatabase("Diplom");

            OrdersCollection = db.GetCollection<OnlineOrder>("Orders");
            OrdersFulfilledCollection = db.GetCollection<OnlineOrder>("FulfilledOrders");
        }
    }
}
