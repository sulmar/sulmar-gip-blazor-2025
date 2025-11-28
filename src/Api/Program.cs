using Domain.Abstractions;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICustomerRepository, FakeCustomerRepository>();
builder.Services.AddScoped<SqlConnection>(sp => new SqlConnection(builder.Configuration.GetConnectionString("MyConnection")));

var app = builder.Build();

// Minimal Api

app.MapGet("/", () => "Hello World!");

app.MapGet("api/customers", (ICustomerRepository repository) => repository.GetAll()); // Wstrzykiwanie zaleznosci
app.MapGet("api/customers/{id}", (int id, ICustomerRepository repository) => repository.Get(id));

app.Run();
