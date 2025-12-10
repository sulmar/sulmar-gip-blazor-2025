using Application.Services;
using MudBlazor.Services;
using MudBlazorWebAssemblyApp.Client.Pages;
using MudBlazorWebAssemblyApp.Components;

var builder = WebApplication.CreateBuilder(args);

// Add MudBlazor services
builder.Services.AddMudServices();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

// dotnet add package Microsoft.Extensions.Http
builder.Services.AddHttpClient<IAsyncCustomerService, ApiCustomerService>(
    http => http.BaseAddress = new Uri("https://localhost:7247"));

builder.Services.AddHttpClient<IAsyncProductService, ApiProductService>(
    http => http.BaseAddress = new Uri("https://localhost:7247"));

builder.Services.AddHttpClient<IAsyncRegionService, ApiRegionService>(
    http => http.BaseAddress = new Uri("https://localhost:7247"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(MudBlazorWebAssemblyApp.Client._Imports).Assembly);

app.Run();
