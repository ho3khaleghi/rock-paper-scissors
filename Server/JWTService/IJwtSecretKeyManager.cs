using JWTService.Model;
using Microsoft.Extensions.Configuration;

namespace JWTService
{
    public interface IJwtSecretKeyManager
    {
        static JwtSecretKey CurrentActiveJwtKey { get; } = null!;
    }
}
