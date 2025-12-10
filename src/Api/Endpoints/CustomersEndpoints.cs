using Domain.Abstractions;

namespace Api.Endpoints;

public static class CustomersEndpoints
{
    // Metoda rozszerzajaca (Extension Methods)
    public static void MapCustomersEndpoints(this IEndpointRouteBuilder routes, string prefix = "api/customers")
    {
        var group = routes.MapGroup(prefix);

        group.MapGet("", (ICustomerRepository repository) => repository.GetAll()); // Wstrzykiwanie zaleznosci
        group.MapGet("/archive", (ICustomerRepository repository) => repository.GetArchive());
        group.MapGet("{id}", (int id, ICustomerRepository repository) => repository.Get(id));
    }
}


public static class DateTimeExtensions
{
    // Metoda rozszerzajaca (Extension Methods)
    // Dokleja funkcję do istniejacego typu np. DateTime
    // Warunki, ktore trzeba spelnic:
    // 1. Klasa musi byc statyczna (static class)
    // 2. Metoda musi byc statyczna (public static)
    // 3. Slowo kluczowe this 
    public static bool IsHoliday(this DateTime date) 
    {
        return date == DateTime.Parse("2025-12-10");
    }
}
