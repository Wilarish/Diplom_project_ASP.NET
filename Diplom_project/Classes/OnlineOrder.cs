using Microsoft.AspNetCore.SignalR.Protocol;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Diplom_project.Classes
{
    public class OnlineOrderCreate
    {
        public CustomerInfo CustomerInfo;
        public FlowerType[] FlowerType;
        public int TotalSum;


        public OnlineOrderCreate( CustomerInfo _customerInfo, FlowerType[] _flowerType, int _totalSum)
        {
            CustomerInfo = _customerInfo;
            FlowerType = _flowerType;
            TotalSum = _totalSum;
        }
    }
  
    public class OnlineOrder
    {
        [BsonId]
        public ObjectId OrderId { get; set; }

        [BsonElement("CustomerInfo")]
        public CustomerInfo CustomerInfo { get; set; }

        [BsonElement("FlowerType")]
        public FlowerType[] FlowerType { get; set; }

        [BsonElement("CreatedAt")]
        public DateTime CreatedAt { get; set; }

        [BsonElement("CompletedAt")]
        public DateTime CompletedAt { get; set; }

        [BsonElement("IsFulfilled")]
        public bool IsFulfilled { get; set; }

        [BsonElement("TotalSum")]
        public int TotalSum { get; set; }


        public OnlineOrder( CustomerInfo _customerInfo, FlowerType[] _flowerType, bool _isFulfilled, int _totalSum)
        {
            OrderId = new ObjectId();
            CustomerInfo = _customerInfo;
            FlowerType = _flowerType;
            CreatedAt = DateTime.Now;
            CompletedAt = DateTime.MinValue;
            IsFulfilled = _isFulfilled;
            TotalSum = _totalSum;

        }
    }
    public class FlowerType
    {
        public string FlowerName;
        public int Cost;
        public string FlowerTypeId;

        public FlowerType(string _flowerName, int _cost, string _flowerTypeId)
        {
            FlowerName = _flowerName;
            Cost = _cost;
            FlowerTypeId = _flowerTypeId;
        }
    }

    [BsonIgnoreExtraElements]
    public class CustomerInfo
    {
        [BsonId]
        public ObjectId OrderId { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Address")]
        public string Address { get; set; }

        [BsonElement("PhoneNumber")]
        public string PhoneNumber { get; set; }
       

        public CustomerInfo(string _name, string _address, string _phoneNumber)
        {
            Name = _name;
            Address = _address;
            PhoneNumber = _phoneNumber;
        }
    }
}
