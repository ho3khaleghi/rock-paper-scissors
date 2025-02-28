using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace JWTService.Extensions
{
    public static class JwtConfigurationExtension
    {

        public static void AddJwtToServices(this IServiceCollection services)
        {
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = JwtSecretKeyManager.JwtSetting.Issuer,
                        ValidAudience = JwtSecretKeyManager.JwtSetting.Audience,
                        RequireExpirationTime = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JwtSecretKeyManager.CurrentActiveJwtKey.SecretKey))
                    };

                    // Add event hooks for JWT Bearer events here
                });
        }

        public static void ReadJwtConfiguration(this IConfiguration configuration) => JwtSecretKeyManager.InitializeManager(configuration);
    }
}
