using Domain.Abstractions;

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
    }
}
