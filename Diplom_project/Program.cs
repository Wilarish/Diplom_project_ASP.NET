using Diplom_project.Repositories;
using Diplom_project.Services;
using FlowerShop.Controllers;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver.Core.Configuration;
using MongoDB.Driver;
using MongoDB.Bson;
using Diplom_project.Classes;

var builder = WebApplication.CreateBuilder(args);


DbCollections.DbConnection();


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
