using Core.Kernel.Dependency;
using RockPaperScissors.Repository.Dtos;
using RockPaperScissors.Repository.Enums;

namespace RockPaperScissors.Repository.Battle
{
    public interface IBattleRepository : ISingletonDependencyInjection
    {
        bool TryAddBattle(BattleDto battle);
        bool TryAddPlayerChoice(Guid battleId, string playerId, PlayerChoice playerChoice);
        bool TryCheckWinner(Guid battleId, out string? winnerId);
        IEnumerable<BattleUpdateNotificationDto?> GetPlayersLastChoice();
    }
}
