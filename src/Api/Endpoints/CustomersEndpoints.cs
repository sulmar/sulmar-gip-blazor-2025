using Domain.Abstractions;
using Domain.Models;

namespace Api.Endpoints;

public static class CustomersEndpoints
{
    // Metoda rozszerzajaca (Extension Methods)
    public static void MapCustomersEndpoints(this IEndpointRouteBuilder routes, string prefix = "api/customers")
    {
        var group = routes.MapGroup(prefix);

        group.MapGet("/", (ICustomerRepository repository) => repository.GetAll()); // Wstrzykiwanie zaleznosci
        group.MapGet("/archive", (ICustomerRepository repository) => repository.GetArchive());
        group.MapGet("{id}", (int id, ICustomerRepository repository) => repository.Get(id));
        group.MapPut("{id}", (int id, Customer customer, ICustomerRepository repository) => repository.Update(id, customer));
    }
}
