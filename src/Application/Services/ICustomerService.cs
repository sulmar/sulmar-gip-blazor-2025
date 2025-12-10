using Domain.Models;
using System.Net.Http.Json;

namespace Application.Services;


// Primary Constructor
public class ApiCustomerService(HttpClient http): IAsyncCustomerService
{
    public Task<List<Customer>?> GetActive() => http.GetFromJsonAsync<List<Customer>>("api/customers");
    public Task<List<Customer>?> GetAll() => http.GetFromJsonAsync<List<Customer>>("api/customers");
    public Task<List<Customer>?> GetArchive() => http.GetFromJsonAsync<List<Customer>>("api/customers/archive");
}
