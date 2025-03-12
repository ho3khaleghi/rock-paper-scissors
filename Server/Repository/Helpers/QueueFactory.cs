using RockPaperScissors.Repository.Enums;
using RockPaperScissors.Repository.Queue;

namespace RockPaperScissors.Repository.Helpers
{
    public class QueueFactory(IBestOfOneQueueRepository bestOfOneQueueRepository,
                              IBestOfThreeQueueRepository bestOfThreeQueueRepository,
                              IBestOfFiveQueueRepository bestOfFiveQueueRepository) : IQueueFactory
    {
        private readonly Dictionary<GameOption, IMatchmakingQueueRepository> _queueRepository = new ()
                {
                    { GameOption.BestOfOne, bestOfOneQueueRepository },
                    { GameOption.BestOfThree, bestOfThreeQueueRepository },
                    { GameOption.BestOfFive, bestOfFiveQueueRepository }
                };

        public IMatchmakingQueueRepository CreateQueueRepository(GameOption gameOption) => _queueRepository[gameOption];
    }
}
