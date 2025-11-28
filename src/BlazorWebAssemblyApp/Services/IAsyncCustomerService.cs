using Domain.Models;

namespace BlazorWebAssemblyApp.Services;

public interface IAsyncCustomerService : IAsyncEntityService<Customer>
{
    Task<List<Customer>?> GetActive();
    Task<List<Customer>?> GetArchive();
}
