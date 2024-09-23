using Microsoft.AspNetCore.Mvc;
using TaxCalculator.Application.Extensions;
using TaxCalculator.Application.Services.Abstractions;
using TaxCalculator.Infrastructure.Extensions;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication();
builder.Services.AddInfrastructure();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/CalculateTax", async ([FromServices] ICalculateTaxService taxCalculateService) =>
{
  return await taxCalculateService.CalculateTaxForYear(2024, "Gothenburg");

})
.WithName("Calculate")
.WithOpenApi();

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
