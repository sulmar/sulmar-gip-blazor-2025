using Domain.Models;
using System.Net.Http.Json;

namespace Application.Services;

public class ApiProductService(HttpClient http) : IAsyncProductService
{
    public Task<List<Product>?> GetAll() => http.GetFromJsonAsync<List<Product>>("api/products");
    public Task<Product?> GetById(int id) => http.GetFromJsonAsync<Product?>($"api/products/{id}");
}
