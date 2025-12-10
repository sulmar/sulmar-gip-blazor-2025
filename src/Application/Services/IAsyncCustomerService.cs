using Domain.Models;

namespace Application.Services;

public interface IAsyncCustomerService : IAsyncEntityService<Customer>
{
    Task<List<Customer>?> GetActive();
    Task<List<Customer>?> GetArchive();
}
