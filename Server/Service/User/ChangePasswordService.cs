using System.Security.Cryptography;
using Core.Kernel.Utils;
using JWTService;
using RockPaperScissors.Repository;
using RockPaperScissors.Repository.Dtos;

namespace RockPaperScissors.Service.User;

public class ChangePasswordService(IUserRepository userRepository, IUserTokenManager userTokenManager) : IChangePasswordService
{
    public async Task<ChangePasswordDto?> HandleAsync(ChangePasswordDto? requestDto)
    {
        if (requestDto == null || requestDto.UserId == 0 || requestDto.CurrentPassword is null || requestDto.NewPassword is null) return null;

        var user = await userRepository.GetAsync(requestDto.UserId);

        if (user == null) return null;

        var hashedPassword = HashUtil.CalculatePasswordHash(requestDto.CurrentPassword, user.Salt!);

        if (!CryptographicOperations.FixedTimeEquals(hashedPassword, user.Password)) return null;
        
        var salt = RandomNumberGenerator.GetBytes(32);

        user.Password = HashUtil.CalculatePasswordHash(requestDto.NewPassword!, salt);
        user.Salt = salt;
        user.RefreshToken = null;

        await userRepository.ChangePasswordAsync(user);
        
        return requestDto;
    }
}