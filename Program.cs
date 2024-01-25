using Microsoft.EntityFrameworkCore;
using NewShoreTest.Business.ExternalServices;
using NewShoreTest.Business.Interfaces;
using NewShoreTest.Business.Ports;
using NewShoreTest.Business.Services;
using NewShoreTest.DataAccess;
using NewShoreTest.DataAccess.Context;
using NewShoreTest.DataAccess.Interfaces;
using NewShoreTest.DataAccess.IRepositories;
using NewShoreTest.DataAccess.Repositories;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddHttpClient();
builder.Services.AddDbContext<NewShoreTestContext>(options =>
            options.UseSqlServer("Name=ConnectionStrings:NewShoreTest"));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Configurar los contenedores de servicios o DI
builder.Services.AddScoped<INewShoreAirFlightsService, NewShoreAirFlightsService>();
builder.Services.AddScoped<IFlightService, FlightService>();
builder.Services.AddScoped<ITransportRepository, TransportRepository>();
builder.Services.AddScoped<IFlightRepository, FlightRepository>();
builder.Services.AddScoped<IJourneyRepository, JourneyRepository>();
builder.Services.AddScoped<IJourneyService, JourneyService>(); 

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
