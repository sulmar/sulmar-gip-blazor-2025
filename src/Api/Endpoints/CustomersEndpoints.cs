using Domain.Abstractions;
using Domain.Models;
using FluentValidation;

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


        group.MapPost("/", (Customer customer, AbstractValidator<Customer> validator, ICustomerRepository repository) =>
        {            
            var result = validator.Validate(customer);

            if (result.IsValid)
            {
                if (customer.Code == "123-abc")
                    throw new InvalidOperationException("123-abc symbol niedozwolony");

                repository.Add(customer);
                
                return Results.Created();
            }

            return Results.BadRequest(result.Errors);

        });
    }
}
