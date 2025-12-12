using Microsoft.AspNetCore.SignalR;

namespace Api.Hubs;

// SignalR - umozliwia dwukierunkowa transmisje danych za pomoca WebSocket
public class DashboardHub(ILogger<DashboardHub> logger) : Hub
{
    public override Task OnConnectedAsync()
    {
        logger.LogInformation($"Connected {this.Context.ConnectionId}");
        
        // Przydzielanie do grupy na podstawie autoryzacji
        //if (this.Context.User.HasClaim(c=>c.Type == "Departament"))
        //{
        //    this.Groups.AddToGroupAsync(this.Context.ConnectionId, 
        //                                this.Context.User.Claims.Single(c=>c.Type == "Department").Value);
        //}

        this.Groups.AddToGroupAsync(this.Context.ConnectionId, "A");
     

        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        logger.LogInformation($"Disconnected {this.Context.ConnectionId}");

        return base.OnDisconnectedAsync(exception);
    }
}
