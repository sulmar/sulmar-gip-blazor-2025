using Domain.Abstractions;

namespace Api.Endpoints;

public static class RegionsEndpoints
{
    public static void MapRegionsEndpoints(this IEndpointRouteBuilder routes, string prefix = "api/regions")
    {
        var group = routes.MapGroup(prefix);

        group.MapGet("/", (IRegionRepository repository) => repository.GetAll()); // Wstrzykiwanie zaleznosci
    }
}
