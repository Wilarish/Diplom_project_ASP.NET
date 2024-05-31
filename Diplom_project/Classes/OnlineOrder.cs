using Microsoft.AspNetCore.SignalR.Protocol;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Diplom_project.Classes
{
    public class OnlineOrderCreate
    {
        public CustomerInfo CustomerInfo;
        public BouquetType[] FlowerType;
        public int TotalSum;


        public OnlineOrderCreate( CustomerInfo _customerInfo, BouquetType[] _flowerType, int _totalSum)
        {
            CustomerInfo = _customerInfo;
            FlowerType = _flowerType;
            TotalSum = _totalSum;
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
            //var bouquetArr = new BsonArray();
            //foreach (var bouquet in _bouquetType)
            //{
            //    bouquetArr.Add(bouquet.ToString());
            //}

            //BouquetType = new BsonDocument("bouquetType", bouquetArr);

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

        public BouquetType(string _flowerName, int _cost)
        {
            FlowerName = _flowerName;
            Cost = _cost;
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


        public CustomerInfo(string _name, string _address, string _phoneNumber)
        {
            Name = _name;
            Address = _address;
            PhoneNumber = _phoneNumber;
        }
    }
}
