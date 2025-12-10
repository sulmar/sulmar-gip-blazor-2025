using Application.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// dotnet add package Microsoft.Extensions.Http
builder.Services.AddHttpClient<IAsyncCustomerService, ApiCustomerService>(
    http => http.BaseAddress = new Uri("https://localhost:7247"));

builder.Services.AddHttpClient<IAsyncProductService, ApiProductService>(
    http => http.BaseAddress = new Uri("https://localhost:7247"));

builder.Services.AddHttpClient<IAsyncRegionService, ApiRegionService>(
    http => http.BaseAddress = new Uri("https://localhost:7247"));

builder.Services.AddMudServices();

await builder.Build().RunAsync();
