using FranksCarLot.Data.Context;
using FranksCarLot.Services.CarLotServices;
using FranksCarLot.Services.CarServices;
using FranksCarLot.Services.CustomerPurchaseServices;
using FranksCarLot.Services.CustomerServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<FranksDbContext>(options => options
        .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Register Services
builder.Services.AddScoped<ICarLotService,CarLotService>();
builder.Services.AddScoped<ICarService,CarService>();
builder.Services.AddScoped<ICustomerPurchaseService,CustomerPurchaseService>();
builder.Services.AddScoped<ICustomerService,CustomerService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
