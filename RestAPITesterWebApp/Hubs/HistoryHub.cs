using Microsoft.AspNetCore.SignalR;

namespace RestAPITesterWebApp.Hubs;

public class HistoryHub : Hub
{
    public async Task AddHistory(string message)
    {
        await Clients.All.SendAsync("GetHistory", message);
    }
}
