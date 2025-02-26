using JWTService.Model;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWTService
{
    public class UserTokenManager : IUserTokenManager
    {
        private readonly ILogger<UserTokenManager> _logger;

        public UserTokenManager(ILogger<UserTokenManager> logger)
        {
            _logger = logger;
        }

        public string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtKey = JwtSecretKeyManager.CurrentActiveJwtKey;
            var key = Encoding.ASCII.GetBytes(jwtKey.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                [
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                ]),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            
            var token = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);

            token.Header.Add("kid", jwtKey.KeyId.ToString());

            return tokenHandler.WriteToken(token);
        }

        public ClaimsPrincipal? GetPrincipal(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtKey = JwtSecretKeyManager.CurrentActiveJwtKey;
            var key = Encoding.ASCII.GetBytes(jwtKey.SecretKey);
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            };

            try
            {
                var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);
                var jwtSecurityToken = securityToken as JwtSecurityToken;

                if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                {
                    throw new SecurityTokenException("Invalid token");
                }

                if (jwtSecurityToken.Header.Kid != jwtKey.KeyId.ToString())
                {
                    // Token was signed with a different key
                    // TODO: Implement key rotation
                    throw new SecurityTokenException("Invalid token");
                }

                return principal;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error validating token");
                return null;
            }
        }
    }
}
