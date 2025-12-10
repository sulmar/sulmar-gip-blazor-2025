using Api.Endpoints;
using Domain.Abstractions;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICustomerRepository, FakeCustomerRepository>();
builder.Services.AddScoped<SqlConnection>(sp => new SqlConnection(builder.Configuration.GetConnectionString("MyConnection")));



builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
       policy.WithOrigins("https://localhost:7283");
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

// app.MapGet("api/products", (IProductRepository repository) => repository.GetAll());

app.Run();
