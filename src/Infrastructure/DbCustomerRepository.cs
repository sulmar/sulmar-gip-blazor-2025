using Domain.Abstractions;
using Domain.Models;
using System.IO.Pipes;

namespace Infrastructure;

public class SqlConnection
{
    public SqlConnection(string connectionString)
    {        
    }
}

public class DbCustomerRepository : ICustomerRepository
{
    private readonly SqlConnection connection;

    public DbCustomerRepository(SqlConnection connection)
    {
        this.connection = connection;
    }

    public Customer Get(int id)
    {
        throw new NotImplementedException();
    }

    public List<Customer> GetAll()
    {
        throw new NotImplementedException();
    }

    public List<Customer> GetArchive()
    {
        throw new NotImplementedException();
    }
}
