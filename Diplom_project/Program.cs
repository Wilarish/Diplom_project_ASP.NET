using Diplom_project.Services;
using FlowerShop.Controllers;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
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

//var container = new ServiceCollection()
//    .AddTransient<OrderService>()
//    .AddTransient<OrdersController>();

//using var serviceProvider = container.BuildServiceProvider();




app.Run();
