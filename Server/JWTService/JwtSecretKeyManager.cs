using Common;
using JWTService.Model;
using System.Text.Json;

namespace JWTService
{
    public class JwtSecretKeyManager : IJwtSecretKeyManager
    {
        private readonly static string _filePath = $"{AppContext.BaseDirectory}\\settings.json";

        private static JwtSecretKey? _oldSecretKey;
        private static JwtSecretKey? _currentActiveJwtKey;

        public static JwtSecretKey CurrentActiveJwtKey
        {
            get
            {
                if (_currentActiveJwtKey == null) InitializeCurrentSecretKey();
                if (_currentActiveJwtKey?.ExpiresAt < DateTime.UtcNow) RotateSecretKey();

                return _currentActiveJwtKey ?? throw new Exception("Current active secret key is null!!!");
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
            if (!File.Exists(_filePath)) return null;

            var json = File.ReadAllText(_filePath);

            return JsonSerializer.Deserialize<JwtSetting?>(json);
        }

        private static void InitializeCurrentSecretKey()
        {
            var jwtSettings = RetrieveJwtSettings();

            if (jwtSettings == null || jwtSettings.ActiveSecretKey == null)
            {
                lock (_filePath)
                {
                    jwtSettings = RetrieveJwtSettings();

                    if (jwtSettings == null || jwtSettings.ActiveSecretKey == null)
                    {
                        _currentActiveJwtKey = CreateSecretKey();

                        return;
                    }
                }
            }

            _currentActiveJwtKey = jwtSettings.ActiveSecretKey;
        }

        private static void RotateSecretKey()
        {
            lock (_filePath)
            {
                if(_currentActiveJwtKey?.ExpiresAt > DateTime.UtcNow) return;

                _oldSecretKey = new JwtSecretKey
                {
                    KeyId = _currentActiveJwtKey!.KeyId,
                    SecretKey = _currentActiveJwtKey.SecretKey,
                    CreatedAt = _currentActiveJwtKey.CreatedAt,
                    ExpiresAt = _currentActiveJwtKey.ExpiresAt,
                    IsActive = false
                };
                _currentActiveJwtKey = CreateSecretKey();
            }
        }
    }
}
