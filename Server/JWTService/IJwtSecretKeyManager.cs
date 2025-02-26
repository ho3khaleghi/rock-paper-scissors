using JWTService.Model;

namespace JWTService
{
    public interface IJwtSecretKeyManager
    {
        static JwtSecretKey CurrentActiveJwtKey { get; } = null!;
    }
}
