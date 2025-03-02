using Microsoft.AspNetCore.SignalR;

namespace RockPaperScissors.Api.SignalR
{
    public class RpsHub : Hub
    {
        public async Task SendAsync(string message)
        {
            await Clients.All.SendAsync("Send", message);
        }
    }
}
