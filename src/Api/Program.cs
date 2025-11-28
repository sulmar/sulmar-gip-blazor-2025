var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Minimal Api

app.MapGet("/", () => "Hello World!");

app.MapGet("api/customers", () => "Hello Customers!");
app.MapGet("api/customers/{id}", (int id) => $"Hello Customer #{id}");
    
app.Run();
