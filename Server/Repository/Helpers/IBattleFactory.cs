using Core.Kernel.Dependency;
using RockPaperScissors.Repository.Battle;
using RockPaperScissors.Repository.Enums;

namespace RockPaperScissors.Repository.Helpers
{
    public interface IBattleFactory : ISingletonDependencyInjection
    {
        IBattleRepository CreateBattleRepository(GameOption gameOption);
    }
}
