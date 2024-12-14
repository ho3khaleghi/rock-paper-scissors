using Core.Kernel.Service;
using RockPaperScissors.Repository.Dtos;

namespace RockPaperScissors.Service.User
{
    public class UserService : ServiceWrapper, IUserServiceWrapper
    {
        private readonly ICreateService _createService;
        private readonly ILoginService _loginService;
        private readonly ILogoutService _logoutService;

        public UserService(IServiceHandler serviceHandler,
                           ICreateService createService,
                           ILoginService loginService,
                           ILogoutService logoutService) : base(serviceHandler)
        {
            _createService = createService;
            _loginService = loginService;
            _logoutService = logoutService;
        }

        public Task<bool> CheckUserNameAsync(string userName) => throw new NotImplementedException();

        public async Task<UserDto?> CreateAsync(UserDto? userDto) =>
            (UserDto?)await ServiceHandler.HandleAsync<UserDto>(async () => await _createService.HandleAsync(userDto));

        public Task<UserDto> DeleteAsync(int id) => throw new NotImplementedException();

        public Task<UserDto> GetAsync(int id) => throw new NotImplementedException();

        public Task<UserDto> GetAsync(string userName) => throw new NotImplementedException();

        public async Task<UserDto?> LoginAsync(string? userName, byte[]? password) => await _loginService.HandleAsync(new UserDto { UserName = userName, Password = password });

        public async Task<UserDto> LogoutAsync(UserDto userDto) => await _logoutService.HandleAsync(userDto);

        public Task<UserDto?> UpdateAsync(UserDto? userDto) => throw new NotImplementedException();
    }
}
