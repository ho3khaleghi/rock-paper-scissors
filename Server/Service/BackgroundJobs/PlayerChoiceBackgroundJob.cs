using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RockPaperScissors.Repository.Battle;
using RockPaperScissors.Repository.Dtos;
using RockPaperScissors.Repository.Enums;
using RockPaperScissors.Repository.Helpers;
using RockPaperScissors.Service.Hubs;

namespace RockPaperScissors.Service.BackgroundJobs
{
    public class PlayerChoiceBackgroundJob : BackgroundService
    {
        private readonly ILogger<PlayerChoiceBackgroundJob> _logger;
        private readonly IHubContext<RpsHub> _hubContext;
        private readonly IBattleRepository _battleRepository;

        private readonly TimeSpan _interval = TimeSpan.FromSeconds(1);

        public PlayerChoiceBackgroundJob(
            IBattleRepository battleRepository,
            ILogger<PlayerChoiceBackgroundJob> logger,
            IHubContext<RpsHub> hubContext)
        {
            _logger = logger;
            _hubContext = hubContext;
            _battleRepository = battleRepository;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation($"{nameof(PlayerChoiceBackgroundJob)} service started.");

            while (!stoppingToken.IsCancellationRequested)
            {
                var tasks = new List<Task>();
                try
                {
                    foreach (var playerLastChoice in _battleRepository.GetPlayersLastChoice())
                    {
                        if (playerLastChoice is null) break;

                        tasks.Add(NotifyPlayers(playerLastChoice));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Error occurred during {nameof(PlayerChoiceBackgroundJob)}.");
                }

                await Task.WhenAll(tasks);
                await Task.Delay(_interval, stoppingToken);
            }

            _logger.LogInformation($"{nameof(PlayerChoiceBackgroundJob)} service stopping...");
        }

        private async Task NotifyPlayers(BattleUpdateNotificationDto notificationDto)
        {
            var data = new
            {
                Player1 = notificationDto.PlayerOneChoice.PlayerId,
                Player1Choice = notificationDto.PlayerOneChoice.PlayerChoices.ToString().ToLower(),
                Player2 = notificationDto.PlayerTwoChoice.PlayerId,
                Player2Choice = notificationDto.PlayerTwoChoice.PlayerChoices.ToString().ToLower()
            };

            await _hubContext.Clients.Group(notificationDto.BattleId.ToString()).SendAsync("PlayersChoice", data);
        }
    }
}
