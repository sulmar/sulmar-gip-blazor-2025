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
            new Customer { Id = 1, Name = "a", Email = "a@domain.com", Region = new Region(0, "Alabama"), Birthday  = DateTime.Parse("1999-12-01"), Salary = 1000 },
            new Customer { Id = 2, Name = "b", Email = "b@domain.com", Region = new Region(1, "Alaska"), Birthday  = DateTime.Parse("1980-12-10"), Salary = 1999  },
            new Customer { Id = 3, Name = "c", Email = "c@domain.com", IsArchived = true },
        }.ToDictionary(p => p.Id);
    }

    public Customer Get(int id)
    {
        Thread.Sleep(2000);

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

    public void Update(int id, Customer customer)
    {
        throw new NotImplementedException();
    }
}
