using Domain.Models;

namespace BlazorWebAssemblyApp.Services;

public interface IAsyncEntityService<T>
    where T : BaseEntity
{
    Task<List<T>> GetAll();

}