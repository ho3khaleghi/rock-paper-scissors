using RockPaperScissors.Repository.Battle;
using RockPaperScissors.Repository.Enums;

namespace RockPaperScissors.Repository.Helpers
{
    public class BattleFactory(IBestOfOneBattleRepository bestOfOneBattleRepository,
                               IBestOfThreeBattleRepository bestOfThreeBattleRepository,
                               IBestOfFiveBattleRepository bestOfFiveBattleRepository) : IBattleFactory
    {
        private readonly Dictionary<GameOption, IBattleRepository> _battleRepository = new()
            {
                { GameOption.BestOfOne, bestOfOneBattleRepository },
                { GameOption.BestOfThree, bestOfThreeBattleRepository },
                { GameOption.BestOfFive, bestOfFiveBattleRepository }
            };

        public IBattleRepository CreateBattleRepository(GameOption gameOption) => _battleRepository[gameOption];
    }
}