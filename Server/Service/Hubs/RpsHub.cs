using Core.Kernel.Dependency;
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
        
        public async Task AcceptChallenge(string matchId, string player)
        {
            await Clients.GroupExcept(matchId, Context.ConnectionId)
                .SendAsync("ChallengeAccepted", player);
        }
    }

    // TODO: This should be removed!!! The userId should be provided by a JWT token.
    public class UsernameBasedUserIdProvider : IUserIdProvider, ISingletonDependencyInjection
    {
        public string GetUserId(HubConnectionContext connection)
        {
            // Assuming you pass username as a query parameter
            var httpContext = connection.GetHttpContext() ?? throw new NullReferenceException();

            return httpContext.Request.Query["username"]!;
        }
    }
}