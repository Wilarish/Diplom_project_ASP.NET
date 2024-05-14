using Microsoft.AspNetCore.SignalR.Protocol;
using MongoDB.Bson;

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
        public ObjectId OrderId;
        public CustomerInfo CustomerInfo;
        public FlowerType[] FlowerType;
        public DateTime CreatedAt;
        public DateTime CompletedAt;
        public bool IsFulfilled;
        public int TotalSum;


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
    public class CustomerInfo
    {
        public string Name;
        public string Address;
        public string PhoneNumber;
       

        public CustomerInfo(string _name, string _address, string _phoneNumber)
        {
            Name = _name;
            Address = _address;
            PhoneNumber = _phoneNumber;
        }
    }
}
