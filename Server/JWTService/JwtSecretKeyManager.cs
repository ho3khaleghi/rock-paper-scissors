using Common;
using Core.Kernel.Dependency;
using JWTService.Model;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace JWTService
{
    public class JwtSecretKeyManager(ILogger<JwtSecretKeyManager> logger) : ISingletonDependencyInjection
    {
        private readonly static string _filePath = $"{AppContext.BaseDirectory}\\settings.json";

        private static JwtSetting? _jwtSettings;
        private static JwtSecretKey? _oldSecretKey;
        private static JwtSecretKey? _currentActiveSecretKey;

        public static JwtSecretKey CurrentActiveSecretKey
        {
            get
            {
                if (_currentActiveSecretKey == null) InitializeCurrentSecretKey();

                return _currentActiveSecretKey ?? throw new Exception("Current active secret key is null!!!");
            }
        }

        private static JwtSecretKey? CreateSecretKey()
        {
            var currentDate = DateTime.UtcNow;
            var secretKey = new JwtSecretKey
            {
                KeyId = Guid.NewGuid(),
                SecretKey = SecretKeyGenerator.Generate(),
                CreatedAt = currentDate,
                ExpiresAt = currentDate.AddMonths(3),
                IsActive = true
            };

            File.WriteAllText(_filePath, JsonSerializer.Serialize(secretKey));

            return secretKey;
        }

        private static JwtSetting? RetrieveJwtSettings()
        {
            if (!File.Exists(_filePath))
            {
                //logger.LogWarning($"{_filePath} file not found.");
                return null;
            }

            var json = File.ReadAllText(_filePath);

            return JsonSerializer.Deserialize<JwtSetting?>(json);
        }

        private static void InitializeCurrentSecretKey()
        {
            _jwtSettings = RetrieveJwtSettings();

            if (_jwtSettings == null || _jwtSettings.ActiveSecretKey == null)
            {
                lock (_filePath)
                {
                    _jwtSettings = RetrieveJwtSettings();

                    if (_jwtSettings == null || _jwtSettings.ActiveSecretKey == null)
                    {
                        _currentActiveSecretKey = CreateSecretKey();

                        return;
                    }
                }
            }

            _currentActiveSecretKey = _jwtSettings.ActiveSecretKey;
        }
    }
}
