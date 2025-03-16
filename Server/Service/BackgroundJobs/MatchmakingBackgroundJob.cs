using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RockPaperScissors.Repository.Dtos;
using RockPaperScissors.Repository.Enums;
using RockPaperScissors.Repository.Helpers;
using RockPaperScissors.Repository.Queue;
using RockPaperScissors.Service.Hubs;

namespace RockPaperScissors.Service.BackgroundJobs
{
    public class MatchmakingBackgroundJob : BackgroundService
    {
        private readonly IQueueFactory _queueFactory;
        private readonly IBattleFactory _battleFactory;
        private readonly ILogger<MatchmakingBackgroundJob> _logger;
        private readonly IHubContext<RpsHub> _hubContext;
        private readonly IMatchmakingQueueRepository _matchmakingQueue;

        private readonly TimeSpan _interval = TimeSpan.FromSeconds(5);

        public MatchmakingBackgroundJob(
            IQueueFactory queueFactory,
            IBattleFactory battleFactory,
            ILogger<MatchmakingBackgroundJob> logger,
            IHubContext<RpsHub> hubContext)
        {
            _queueFactory = queueFactory;
            _battleFactory = battleFactory;
            _logger = logger;
            _hubContext = hubContext;

            _matchmakingQueue = _queueFactory.CreateQueueRepository(GameOption.BestOfThree);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Matchmaking service started.");

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    while (_matchmakingQueue.TryGetNextMatchPlayers(out var match))
                    {
                        _logger.LogInformation($"Match found: {match.player1} vs {match.player2}");

                        await NotifyPlayers(match);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error occurred during matchmaking.");
                }

                await Task.Delay(_interval, stoppingToken);
            }

            _logger.LogInformation("Matchmaking service stopping...");
        }

        private async Task NotifyPlayers((string player1, string player2) match)
        {
            var matchId = Guid.NewGuid();

            if(_battleFactory.CreateBattleRepository(GameOption.BestOfThree)
                .TryAddBattle(new BattleDto
            {
                BattleId = matchId,
                GameOption = GameOption.BestOfThree,
                PlayerOneId = match.player1,
                PlayerTwoId = match.player2
            }))
            {
                _logger.LogInformation($"Battle added: {matchId}");
            }
            else
            {
                _logger.LogError($"Couldn't add battle: {matchId}");
                return;
            }

            var player1Data = new
                { MatchId = matchId, OpponentId = match.player2, GameOption = GameOption.BestOfThree };
            var player2Data = new
                { MatchId = matchId, OpponentId = match.player1, GameOption = GameOption.BestOfThree };

            // Send opponent info to each player individually
            await _hubContext.Clients.User(match.player1).SendAsync("MatchFound", player1Data);
            await _hubContext.Clients.User(match.player2).SendAsync("MatchFound", player2Data);
        }
    }
}