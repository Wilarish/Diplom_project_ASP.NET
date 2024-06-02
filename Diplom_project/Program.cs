using Diplom_project.Repositories;
using Diplom_project.Services;
using FlowerShop.Controllers;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver.Core.Configuration;
using MongoDB.Driver;
using MongoDB.Bson;
using Diplom_project.Classes;

var builder = WebApplication.CreateBuilder(args);


//string mongoUrl = "mongodb+srv://tararammmm2004:w5iGTWlkB8HFRjes@cluster0.vwzbeey.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";

string mongoUrl = "mongodb://localhost:27017";

MongoClient client = new MongoClient(mongoUrl);
IMongoDatabase db = client.GetDatabase("Diplom");

DbCollections.OrdersCollection = db.GetCollection<OnlineOrder>("Orders");
DbCollections.OrdersFulfilledfCollection = db.GetCollection<OnlineOrder>("FulfilledOrders");


BouquetType[] arr = { new BouquetType("rose", 1000, 1), new BouquetType("romashka", 500, 1)};


OnlineOrder order = new OnlineOrder(new CustomerInfo("Ivan", "Moscow","8-800-999"), arr, false, 1500);



DbCollections.OrdersCollection.InsertOne(order);



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddTransient<FulfilledOrdersRepository>()
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
