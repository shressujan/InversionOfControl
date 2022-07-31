using System.Reflection;
using Api;
using AutoMapper;
using Data;
using Service;
using Service.DataAccess;
using Service.Mapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IParkingRepository, MongoParkingRepository>();
builder.Services.AddSingleton<IParkingApi, ParkingService>();

static Assembly[] GetAutoMapperAssembliesToScan()
    => new[]
    {
        typeof(VehicleProfile).Assembly,
        typeof(Program).Assembly
    }.Distinct().ToArray();

builder.Services.AddAutoMapper(GetAutoMapperAssembliesToScan());

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
