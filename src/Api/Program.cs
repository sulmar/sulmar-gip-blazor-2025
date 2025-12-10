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

app.MapGet("api/customers", (ICustomerRepository repository) => repository.GetAll()); // Wstrzykiwanie zaleznosci
app.MapGet("api/customers/archive", (ICustomerRepository repository) => repository.GetArchive());
app.MapGet("api/customers/{id}", (int id, ICustomerRepository repository) => repository.Get(id));

// app.MapGet("api/products", (IProductRepository repository) => repository.GetAll());

app.Run();
