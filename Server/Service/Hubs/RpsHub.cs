using Core.Kernel.Dependency;
using Microsoft.AspNetCore.SignalR;
using RockPaperScissors.Repository.Enums;
using RockPaperScissors.Repository.Helpers;

namespace RockPaperScissors.Service.Hubs
{
    public class RpsHub(IBattleFactory battleFactory) : Hub
    {
        public async Task JoinMatch(string matchId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, matchId);
        }

        public async Task SendChoice(string matchId, string player, string playerChoice)
        {
            var playerChoiceValue = Enum.Parse<PlayerChoice>(playerChoice, true);
            var battleRepository = battleFactory.CreateBattleRepository(GameOption.BestOfThree);

            if (!battleRepository.TryAddPlayerChoice(Guid.Parse(matchId), player, playerChoiceValue)) return;

            if (battleRepository.TryCheckWinner(Guid.Parse(matchId), out var winnerId))
            {
                await Clients.Group(matchId).SendAsync("MatchWinner", winnerId);
            }
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