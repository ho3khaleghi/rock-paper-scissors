using RockPaperScissors.Repository.Dtos;

namespace RockPaperScissors.Repository.Battle
{
    public interface IBattleRepository
    {
        bool TryAddBattle(BattleDto battle);
    }
}
