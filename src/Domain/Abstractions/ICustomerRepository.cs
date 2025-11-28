using Domain.Models;

namespace Domain.Abstractions;

public interface ICustomerRepository
{
    List<Customer> GetAll();
    List<Customer> GetArchive();
    Customer Get(int id);
}
