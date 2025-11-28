using Domain.Models;
using System.Net.Http.Json;

namespace BlazorWebAssemblyApp.Services;

public interface IAsyncCustomerService
{
    Task<List<Customer>?> GetActive();
    Task<List<Customer>?> GetArchive();
}


// Primary Constructor
public class ApiCustomerService(HttpClient http): IAsyncCustomerService
{
    public Task<List<Customer>?> GetActive() => http.GetFromJsonAsync<List<Customer>>("api/customers");
    public Task<List<Customer>?> GetArchive() => http.GetFromJsonAsync<List<Customer>>("api/customers/archive");
}
