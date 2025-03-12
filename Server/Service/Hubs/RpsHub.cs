using Microsoft.AspNetCore.SignalR;

namespace RockPaperScissors.Service.Hubs
{
    public class RpsHub : Hub
    {
        public async Task JoinMatch(string matchId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, matchId);
        }

        public async Task SendChoice(string matchId, string player, string playerChoice)
        {
            // Sends the move to all clients in the group except the sender.
            await Clients.GroupExcept(matchId, Context.ConnectionId)
                         .SendAsync("OpponentChoice", player, playerChoice);
        }
    }
}
