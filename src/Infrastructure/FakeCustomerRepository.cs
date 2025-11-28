using Domain.Abstractions;
using Domain.Models;

namespace Infrastructure;

public class FakeCustomerRepository : ICustomerRepository
{
    private readonly Dictionary<int, Customer> _customers;

    public FakeCustomerRepository()
    {
        _customers = new List<Customer>
        {
            new Customer { Id = 1, Name = "a", Email = "a@domain.com"},
            new Customer { Id = 2, Name = "b", Email = "b@domain.com"},
            new Customer { Id = 3, Name = "c", Email = "c@domain.com", IsArchived = true },
        }.ToDictionary(p => p.Id);
    }

    public Customer Get(int id)
    {
        return _customers[id];
    }

    public List<Customer> GetAll()
    {        
        return _customers.Values.Where(c => !c.IsArchived).ToList();
    }

    public List<Customer> GetArchive()
    {
        return _customers.Values.Where(c => c.IsArchived).ToList();
    }
}
