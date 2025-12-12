using Domain.Abstractions;
using Domain.Models;

namespace Infrastructure;

public class FakeDocumentService : IDocumentService
{
    public async Task Generate(Customer customer, IProgress<int> progress = null)
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"Generacja dla {customer.Name} krok {i}...");

            progress?.Report(i);

            await Task.Delay(Random.Shared.Next(500, 2000));
            
        }

        Console.WriteLine($"Dokument dla {customer.Name} Gotowy.");
    }
}
