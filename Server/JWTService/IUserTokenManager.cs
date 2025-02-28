using Core.Kernel.Dependency;
using JWTService.Model;
using System.Security.Claims;

namespace JWTService
{
    public interface IUserTokenManager : IDependencyInjection
    {
        string GenerateToken(User user);
        ClaimsPrincipal? GetPrincipal(string token);
    }
}