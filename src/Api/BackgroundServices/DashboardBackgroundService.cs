
using Api.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace Api.BackgroundServices;

public class DashboardBackgroundService(
    ILogger<DashboardBackgroundService> logger,
    IHubContext<DashboardHub> hub
    ) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            // Symulacja wartosci
            var item = new DashboardItem(Random.Shared.Next(0, 100), Random.Shared.Next(10, 20));

            logger.LogInformation("Send DashboardChanged {Sessions} {ProductCount}", item.Sessions, item.ProductCount);

            // Wyslij komunikat DashboardChanged do klienta
            // await hub.Clients.All.SendAsync("DashboardChanged", item);

            await hub.Clients.Groups("A").SendAsync("DashboardChanged", item);

            await Task.Delay(Random.Shared.Next(1000, 2000));
        }
    }
}

public record DashboardItem(int Sessions, int ProductCount);