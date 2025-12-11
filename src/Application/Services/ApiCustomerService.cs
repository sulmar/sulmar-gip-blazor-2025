using Domain.Models;
using System.Net.Http.Json;

namespace Application.Services;


// Primary Constructor
public class ApiCustomerService(HttpClient http): IAsyncCustomerService
{
    public async Task Add(Customer customer)  => (await http.PostAsJsonAsync("api/customers", customer)).EnsureSuccessStatusCode();
    public Task<List<Customer>?> GetActive() => http.GetFromJsonAsync<List<Customer>>("api/customers");
    public Task<List<Customer>?> GetAll() => http.GetFromJsonAsync<List<Customer>>("api/customers");
    public Task<List<Customer>?> GetArchive() => http.GetFromJsonAsync<List<Customer>>("api/customers/archive");
    public Task<Customer?> GetById(int id) => http.GetFromJsonAsync<Customer?>($"api/customers/{id}");
}
