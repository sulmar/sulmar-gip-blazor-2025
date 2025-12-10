using Domain.Models;

namespace Domain.Abstractions;

public interface IRegionRepository
{
    List<Region> GetAll();
}