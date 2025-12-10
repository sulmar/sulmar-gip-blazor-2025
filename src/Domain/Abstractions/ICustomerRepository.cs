using Domain.Models;

namespace Domain.Abstractions;

public interface ICustomerRepository : IEntityRepository<Customer>
{
    List<Customer> GetArchive();
    void Update(int id, Customer customer);
}
