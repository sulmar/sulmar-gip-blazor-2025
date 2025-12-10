using Domain.Models;

namespace Application.Services;

public interface IAsyncRegionService
{
    Task<List<Region>?> GetAll();
}