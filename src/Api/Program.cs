using Api.Endpoints;
using Api.Extensions;
using Api.Middlewares;
using Domain.Abstractions;
using Domain.Models;
using Domain.Models.Validators;
using FluentValidation; 
using Infrastructure;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Scalar.AspNetCore;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<SqlConnection>(sp => new SqlConnection(builder.Configuration.GetConnectionString("MyConnection")));
builder.Services.AddSingleton<ICustomerRepository, FakeCustomerRepository>();
builder.Services.AddScoped<IRegionRepository, FakeRegionRepository>();

builder.Services.AddScoped<AbstractValidator<Customer>, CustomerValidator>();


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
       policy.WithOrigins("https://localhost:7283", "https://localhost:7194");
                                                          //   policy.AllowAnyOrigin();        
        policy.WithMethods("GET", "POST", "PUT");
        // policy.AllowAnyMethod();
        policy.AllowAnyHeader();
    });
});

// Rejestracja uslugi do generowania dokumentacji w formacie OpenApi (Swagger)
// dotnet add package Microsoft.AspNetCore.OpenApi
builder.Services.AddOpenApi();

// dotnet add package Scalar.AspNetCore

/* Dodanie autoryzacji
builder.Services.AddAuthentication();
builder.Services.AddAuthorization(options => options.AddPolicy("VIP", policy =>
{
    policy.RequireAuthenticatedUser();
    policy.RequireClaim("gold");
    policy.RequireRole("developer");    
}));
*/

var app = builder.Build();


app.UseCors(); // Middleware

#region
// Warsta posrednia (Middleware)
/*
app.Use(async (context, next) =>
{
    // Logger enter
    Console.WriteLine($"{context.Request.Method} {context.Request.Path}");

    // Auth
    if (!context.Request.Headers.TryGetValue("x-secret-key", out var secretkey) || secretkey != "123abc")
    {
        context.Response.StatusCode = StatusCodes.Status401Unauthorized;

        Console.WriteLine($"{context.Response.StatusCode}");

        return;
    }

    // 

    await next();

    Console.WriteLine($"{context.Response.StatusCode}");
});
*/


// Logger
//app.Use(async (context, next) =>
//{
//    Console.WriteLine($"{context.Request.Method} {context.Request.Path}");

//    await next();

//    Console.WriteLine($"{context.Response.StatusCode}");
//});

// Authorization Secret Key
//app.Use(async (context, next) =>
//{
//    if (!context.Request.Headers.TryGetValue("x-secret-key", out var secretkey) || secretkey != "123abc")
//    {
//        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
//        return;
//    }

//    await next();    
//});

#endregion

// app.UseMiddleware<LoggerMiddleware>();
app.UseLogger();
app.UseSecretKey("abc-123");


// Minimal Api

app.MapGet("/", () => "Hello World!");

// https://localhost:7247/openapi/v1.json
app.MapOpenApi();

// https://localhost:7247/scalar
app.MapScalarApiReference(options =>options.Title = "Blazor Api");

// DateTimeExtensions.IsHoliday(DateTime.Today);
DateTime.Today.IsHoliday(); // Metoda rozszerzajaca

app.MapGet("/secret", (HttpContext context) =>
{
    ClaimsIdentity identity = (ClaimsIdentity) context.User.Identity;

    var email = context.User.FindFirstValue("email");
    
    if (identity.HasClaim("permission", "print"))
    {

    }    

    Console.WriteLine();
});

app.MapCustomersEndpoints();
app.MapRegionsEndpoints();

// app.MapGet("api/products", (IProductRepository repository) => repository.GetAll());

app.Run();
