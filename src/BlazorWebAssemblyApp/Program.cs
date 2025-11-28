using BlazorWebAssemblyApp;
using BlazorWebAssemblyApp.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddHttpClient<IAsyncCustomerService, ApiCustomerService>(
    http => http.BaseAddress = new Uri("https://localhost:7247") );

builder.Services.AddHttpClient<IAsyncProductService, ApiProductService>(
    http => http.BaseAddress = new Uri("https://localhost:7247") );

// dotnet add package Scrutor 
/*
builder.Services.AddStructor(scan =>
{
    scan
        .FromAssemblyOf<IAsyncCustomerService>()
        .AddClasses(c => c.AssignableTo(typeof(IAsyncEntityService<>)))
        .UsingRegistrationStrategy((type, services) =>
        {
            var iface = type.ImplementedInterfaces
                .First(i => !i.IsGenericType ||
                            i.GetGenericTypeDefinition() != typeof(IAsyncEntityService<>));

            services.AddHttpClient(iface, type.Type,
                http => http.BaseAddress = new Uri("https://localhost:7247"));
        });
});

*/

await builder.Build().RunAsync();
