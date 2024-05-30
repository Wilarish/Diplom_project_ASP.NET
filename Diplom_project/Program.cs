using Diplom_project.Repositories;
using Diplom_project.Services;
using FlowerShop.Controllers;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver.Core.Configuration;
using MongoDB.Driver;
using MongoDB.Bson;
using Diplom_project.Classes;

var builder = WebApplication.CreateBuilder(args);


string mongoUrl = "mongodb+srv://tararammmm2004:w5iGTWlkB8HFRjes@cluster0.vwzbeey.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";
MongoClient client = new MongoClient(mongoUrl);
IMongoDatabase db = client.GetDatabase("Diplom");
var collection = db.GetCollection<CustomerInfo>("Orders");


//FlowerType[] arr = { new FlowerType("rose", 1000, "12345"), new FlowerType("romashka", 500, "3214")};


//OnlineOrder order = new OnlineOrder(new CustomerInfo("Ivan", "Moscow","8-800-999"), arr, false, 1500);



collection.InsertOne(new CustomerInfo("Ivan", "Moscow", "8-800-999"));

DbCollections.OrdersCollection = collection;



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddTransient<OrdersRepository>()
    .AddTransient<OrderService>()
    .AddTransient<OrdersController>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
