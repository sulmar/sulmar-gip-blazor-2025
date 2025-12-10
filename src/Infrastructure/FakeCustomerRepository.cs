using Domain.Abstractions;
using Domain.Models;

namespace Infrastructure;


public class FakeRegionRepository : IRegionRepository
{
    private readonly string[] _states =
    {
        "Alabama", "Alaska", "Arizona", "Arkansas", "California",
        "Colorado", "Connecticut", "Delaware", "Florida", "Georgia",
        "Hawaii", "Idaho", "Illinois", "Indiana", "Iowa", "Kansas",
        "Kentucky", "Louisiana", "Maine", "Maryland", "Massachusetts",
        "Michigan", "Minnesota", "Mississippi", "Missouri", "Montana",
        "Nebraska", "Nevada", "New Hampshire", "New Jersey", "New Mexico",
        "New York", "North Carolina", "North Dakota", "Ohio", "Oklahoma",
        "Oregon", "Pennsylvania", "Rhode Island", "South Carolina", "South Dakota",
        "Tennessee", "Texas", "Utah", "Vermont", "Virginia",
        "Washington", "West Virginia", "Wisconsin", "Wyoming"
    };

    public List<Region> GetAll() => _states.Select((item, index) => new Region { Id = index, Name = item }).ToList();
}

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
}
