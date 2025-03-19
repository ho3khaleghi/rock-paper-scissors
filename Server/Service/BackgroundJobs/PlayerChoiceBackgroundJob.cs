using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    public class PlayerChoiceBackgroundJob : BackgroundService
    {
        private readonly IBattleFactory _battleFactory;
        private readonly ILogger<PlayerChoiceBackgroundJob> _logger;
        private readonly IHubContext<RpsHub> _hubContext;

        private readonly TimeSpan _interval = TimeSpan.FromSeconds(5);

        public PlayerChoiceBackgroundJob(
            IBattleFactory battleFactory,
            ILogger<PlayerChoiceBackgroundJob> logger,
            IHubContext<RpsHub> hubContext)
        {
            _battleFactory = battleFactory;
            _logger = logger;
            _hubContext = hubContext;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Matchmaking service started.");

            while (!stoppingToken.IsCancellationRequested)
            {
                //try
                //{
                //    while (_matchmakingQueue.TryGetNextMatchPlayers(out var match))
                //    {
                //        _logger.LogInformation($"Match found: {match.player1} vs {match.player2}");

                //        await NotifyPlayers(match);
                //    }
                //}
                //catch (Exception ex)
                //{
                //    _logger.LogError(ex, "Error occurred during matchmaking.");
                //}

                await Task.Delay(_interval, stoppingToken);
            }

            _logger.LogInformation("Matchmaking service stopping...");
        }

        private async Task NotifyPlayers((string player1, string player2) match)
        {
            var matchId = Guid.NewGuid();

            if (_battleFactory.CreateBattleRepository(GameOption.BestOfThree)
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
