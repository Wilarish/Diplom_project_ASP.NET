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
var collection = db.GetCollection<OnlineOrder>("Orders");


BouquetType[] arr = { new BouquetType("rose", 1000), new BouquetType("romashka", 500)};


OnlineOrder order = new OnlineOrder(new CustomerInfo("Ivan", "Moscow","8-800-999"), arr, false, 1500);



collection.InsertOne(order);

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
