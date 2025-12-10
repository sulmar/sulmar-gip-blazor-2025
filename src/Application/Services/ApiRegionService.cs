using Domain.Models;
using System.Net.Http.Json;

namespace Application.Services;

public class ApiRegionService(HttpClient http) : IAsyncRegionService
{
    public Task<List<Region>?> GetAll() => http.GetFromJsonAsync<List<Region>?>("api/regions");
    public Task<Region?> GetById(int id) => http.GetFromJsonAsync<Region?>($"api/regions/{id}");
}