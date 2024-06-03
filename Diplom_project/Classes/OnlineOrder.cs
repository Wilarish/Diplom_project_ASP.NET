using Microsoft.AspNetCore.SignalR.Protocol;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Diplom_project.Classes
{


    public class OnlineOrderCreate
    {
        [Required(ErrorMessage = "CustomerInfo is required")]
        public CustomerInfo CustomerInfo { get; set; }

        [Required(ErrorMessage = "CustomerInfo is required")]
        [MinLength(1, ErrorMessage = "BouquetTypes must be longer than 1")]
        public BouquetType[] BouquetTypes { get; set; }

        public OnlineOrderCreate(CustomerInfo customerInfo, BouquetType[] bouquetTypes)
        {
            CustomerInfo = customerInfo;
            BouquetTypes = bouquetTypes;
        }
    }
    [BsonIgnoreExtraElements]
    public class OnlineOrderView
    {
        [BsonId]
        public ObjectId OrderId { get; set; }

        [BsonElement("CustomerInfo")]
        public CustomerInfo CustomerInfo { get; set; }

        [BsonElement("BouquetType")]
        public BouquetType[] BouquetType { get; set; }

        [BsonElement("CreatedAt")]
        public DateTime CreatedAt { get; set; }

        [BsonElement("TotalSum")]
        public int TotalSum { get; set; }


        public OnlineOrderView(ObjectId _orderId, CustomerInfo _customerInfo, BouquetType[] _bouquetType, int _totalSum, DateTime _createdAt)
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
        [Required(ErrorMessage = "FlowerName is required")]
        [MinLength(5, ErrorMessage = "FlowerName must be longer than 4, and shorter than 30")]
        [MaxLength(30, ErrorMessage = "FlowerName must be longer than 4, and shorter than 30")]
        public string FlowerName { get; set; }
        
        [BsonElement("Cost")]
        [Required(ErrorMessage = "Cost is required")]
        [Range(100, 30000, ErrorMessage = "Cost must be greater than 0")]
        public int Cost { get; set; }

        [BsonElement("Count")]
        [Required(ErrorMessage = "Count is required")]
        [Range(1, 100, ErrorMessage = "Count must be greater than 0")]
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
        [Required(ErrorMessage = "Name is required")]
        [MinLength(5, ErrorMessage = "Name must be longer than 4, and shorter than 30")]
        [MaxLength(30, ErrorMessage = "Name must be longer than 4, and shorter than 30")]
        public string Name { get; set; }

        [BsonElement("Address")]
        [Required(ErrorMessage = "Address is required")]
        [MinLength(10, ErrorMessage = "Address must be longer than 10, and shorter than 100")]
        [MaxLength(100, ErrorMessage = "Address must be longer than 10, and shorter than 100")]
        public string Address { get; set; }

        [BsonElement("PhoneNumber")]
        [Required(ErrorMessage = "PhoneNumber is required")]
        [Phone(ErrorMessage = "incorrect phoneNumber")]
        [MinLength(10, ErrorMessage = "PhoneNumber must be longer than 10, and shorter than 15")]
        [MaxLength(15, ErrorMessage = "PhoneNumber must be longer than 10, and shorter than 15")]
        public string PhoneNumber { get; set; }

        public CustomerInfo(string name, string address, string phoneNumber)
        {
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
        }
    }
}
