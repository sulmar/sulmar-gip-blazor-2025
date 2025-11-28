using Domain.Models;
using System.Net.Http.Json;

namespace BlazorWebAssemblyApp.Services;

public class ApiProductService(HttpClient http) : IAsyncProductService
{
    public Task<List<Product>?> GetAll() => http.GetFromJsonAsync<List<Product>>("api/products");
}
