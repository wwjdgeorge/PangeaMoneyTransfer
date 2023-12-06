using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using PangeaMoneyTransfer.Application.Service;
using PangeaMoneyTransfer.DB;
using PangeaMoneyTransfer.Interfaces.Application.Service;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddScoped<IServiceConfig, ServiceConfig>();
builder.Services.AddScoped<IExchangeService, ExchangeService>();
builder.Services.AddDbContext<ExchangeDBContext>(options =>
{
    options.UseInMemoryDatabase("Exchange");
});

builder.Services.AddAutoMapper(typeof(Program).Assembly);
var app = builder.Build();

 app.MapControllers();

app.Run();
