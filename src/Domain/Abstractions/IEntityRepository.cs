using Domain.Models;

namespace Domain.Abstractions;

public interface IEntityRepository<T>
    where T : BaseEntity
{
    List<T> GetAll();    
    T Get(int id);
    void Add(T entity);
}

