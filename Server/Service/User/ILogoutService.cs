using Core.Kernel.Service;
using RockPaperScissors.Repository.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.Service.User
{
    public interface ILogoutService : IService<UserDto, UserDto>
    {
    }
}
