using Domain.Models;

namespace Application.Services;

public interface IAsyncEntityService<T>
    where T : BaseEntity
{
    Task<List<T>> GetAll();

}