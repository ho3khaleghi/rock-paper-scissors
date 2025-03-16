using Core.Kernel.Service;
using RockPaperScissors.Service.Battle.Dto;

namespace RockPaperScissors.Service.Battle
{
    public interface IAddBattleService : IService<AddPlayerBattleDto, AddPlayerBattleDto>
    {
    }
}
