using Domain.Models;

namespace Domain.Abstractions;

public interface ICustomerRepository
{
    List<Customer> GetAll();
    Customer Get(int id);
}
