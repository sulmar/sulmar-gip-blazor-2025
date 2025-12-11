using Domain.Models;

namespace Application.Services;

public interface IAsyncEntityService<T>
    where T : BaseEntity
{
    Task<List<T>?> GetAll();
    Task<T?> GetById(int id);
    Task Add(T entity);
    Task Update(T entity);    
}