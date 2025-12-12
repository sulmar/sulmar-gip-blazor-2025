using Application.Services;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using MudBlazorWebAssemblyApp.Client.Handlers;
using MudBlazorWebAssemblyApp.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<LoggerHandler>();
builder.Services.AddScoped<SecretKeyHandler>();

// dotnet add package Microsoft.Extensions.Http
builder.Services.AddHttpClient<IAsyncCustomerService, ApiCustomerService>(
    http => http.BaseAddress = new Uri("https://localhost:7247"))
    .AddHttpMessageHandler<LoggerHandler>()
    .AddHttpMessageHandler<SecretKeyHandler>();

builder.Services.AddHttpClient<IAsyncProductService, ApiProductService>(
    http => http.BaseAddress = new Uri("https://localhost:7247"))
    .AddHttpMessageHandler<LoggerHandler>()
    .AddHttpMessageHandler<SecretKeyHandler>();

builder.Services.AddHttpClient<IAsyncRegionService, ApiRegionService>(
    http => http.BaseAddress = new Uri("https://localhost:7247"))
    .AddHttpMessageHandler<LoggerHandler>()
    .AddHttpMessageHandler<SecretKeyHandler>();


// builder.Services.AddScoped<ILocalStorageService, LocalStorageService>();
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddMudServices();

await builder.Build().RunAsync();
