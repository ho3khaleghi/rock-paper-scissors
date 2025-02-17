using Common;
using Core.Kernel.Dependency;
using JWTService.Model;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace JWTService
{
    public class TokenKeyManager(ILogger<TokenKeyManager> logger) : ISingletonDependencyInjection
    {
        private readonly string _filePath = $"{AppContext.BaseDirectory}\\KeyStorage.json";

        private JwtTokenKey? _oldSecretKey;
        private JwtTokenKey? _currentActiveKey;

        public JwtTokenKey CurrentActiveKey
        {
            get
            {
                if (_currentActiveKey == null) InitializeCurrentKeyAsync();
                
                return _currentActiveKey ?? throw new Exception("Current active key is null!!!");
            }
        }

        private JwtTokenKey? CreateTokenKeyAsync()
        {
            var currentDate = DateTime.UtcNow;
            var tokenKey = new JwtTokenKey
            {
                KID = Guid.NewGuid().ToString(),
                SecretKey = SecretKeyGenerator.Generate(),
                CreatedAt = currentDate,
                ExpiresAt = currentDate.AddMonths(3),
                IsActive = true
            };

            File.WriteAllText(_filePath, JsonSerializer.Serialize(tokenKey));

            return tokenKey;
        }

        private IList<JwtTokenKey?>? RetriveTokenKeyAsync()
        {
            if (!File.Exists(_filePath))
            {
                logger.LogWarning("Token key file not found.");
                return null;
            }

            var json = File.ReadAllText(_filePath);

            return JsonSerializer.Deserialize<IList<JwtTokenKey?>?>(json);
        }

        private void InitializeCurrentKeyAsync()
        {
            var tokenKeys = RetriveTokenKeyAsync();
            if (tokenKeys == null || tokenKeys.Count == 0 || tokenKeys.FirstOrDefault() == null)
            {
                lock (_filePath)
                {
                    tokenKeys = RetriveTokenKeyAsync();
                    
                    if (tokenKeys == null || tokenKeys.Count == 0 || tokenKeys.FirstOrDefault() == null)
                    {
                        _currentActiveKey = CreateTokenKeyAsync();
                    }
                }
            }
        }
    }
}
