using Api.Endpoints;
using Api.Extensions;
using Domain.Abstractions;
using Domain.Models;
using Domain.Models.Validators;
using FluentValidation;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<SqlConnection>(sp => new SqlConnection(builder.Configuration.GetConnectionString("MyConnection")));
builder.Services.AddScoped<ICustomerRepository, FakeCustomerRepository>();
builder.Services.AddScoped<IRegionRepository, FakeRegionRepository>();

builder.Services.AddScoped<AbstractValidator<Customer>, CustomerValidator>();


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
       policy.WithOrigins("https://localhost:7283", "https://localhost:7194");
                                                          //   policy.AllowAnyOrigin();        
        policy.WithMethods("GET");
        // policy.AllowAnyMethod();
        policy.AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseCors(); // Middleware

// Minimal Api

app.MapGet("/", () => "Hello World!");

// DateTimeExtensions.IsHoliday(DateTime.Today);
DateTime.Today.IsHoliday(); // Metoda rozszerzajaca

app.MapCustomersEndpoints();
app.MapRegionsEndpoints();

// app.MapGet("api/products", (IProductRepository repository) => repository.GetAll());

app.Run();
