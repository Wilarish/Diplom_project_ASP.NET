using Microsoft.AspNetCore.SignalR.Protocol;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Diplom_project.Classes
{
   
    
    public class OnlineOrderCreate
    {

        public CustomerInfo CustomerInfo { get; set; }

        public BouquetType[] BouquetType { get; set; }


        public OnlineOrderCreate(CustomerInfo customerInfo, BouquetType[] bouquetType)
        {
            CustomerInfo = customerInfo;
            BouquetType = bouquetType;
        }
    }
    public class OnlineOrderView
    {
        public string OrderId;
        public CustomerInfo CustomerInfo;
        public BouquetType[] BouquetType;
        public DateTime CreatedAt;
        public int TotalSum;


        public OnlineOrderView(string _orderId, CustomerInfo _customerInfo, BouquetType[] _bouquetType, int _totalSum, DateTime _createdAt)
        {
            OrderId = _orderId;
            CustomerInfo = _customerInfo;
            BouquetType = _bouquetType;
            TotalSum = _totalSum;
            CreatedAt = _createdAt;
        }
    }

    [BsonIgnoreExtraElements]
    public class OnlineOrder
    {
        [BsonId]
        public ObjectId OrderId { get; set; }

        [BsonElement("CustomerInfo")]
        public CustomerInfo CustomerInfo { get; set; }

        [BsonElement("BouquetType")]
        public BouquetType[] BouquetType { get; set; }

        [BsonElement("CreatedAt")]
        public DateTime CreatedAt { get; set; }

        [BsonElement("CompletedAt")]
        public DateTime CompletedAt { get; set; }

        [BsonElement("IsFulfilled")]
        public bool IsFulfilled { get; set; }

        [BsonElement("TotalSum")]
        public int TotalSum { get; set; }


        public OnlineOrder( CustomerInfo _customerInfo, BouquetType[] _bouquetType, bool _isFulfilled, int _totalSum)
        {
            OrderId = new ObjectId();
            CustomerInfo = _customerInfo;
            BouquetType = _bouquetType;
            CreatedAt = DateTime.Now;
            CompletedAt = DateTime.MinValue;
            IsFulfilled = _isFulfilled;
            TotalSum = _totalSum;

        }
    }

    [BsonIgnoreExtraElements]
    public class BouquetType
    {
        [BsonElement("FlowerName")]
        public string FlowerName { get; set; }
        
        [BsonElement("Cost")]
        public int Cost { get; set; }

        [BsonElement("Count")]
        public int Count { get; set; }

        public BouquetType(string flowerName, int cost, int count)
        {
            FlowerName = flowerName;
            Cost = cost;
            Count = count;
        }
    }


    [BsonIgnoreExtraElements]
    public class CustomerInfo
    {
   
        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Address")]
        public string Address { get; set; }

        [BsonElement("PhoneNumber")]
        public string PhoneNumber { get; set; }


        public CustomerInfo(string name, string address, string phoneNumber)
        {
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
        }
    }
}
