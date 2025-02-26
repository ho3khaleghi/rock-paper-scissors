using System.Security.Cryptography;

namespace Common
{
    public class SecretKeyGenerator
    {
        public static string Generate()
        {
            var key = new byte[32];

            using (var generator = RandomNumberGenerator.Create())
                generator.GetBytes(key);

            return Convert.ToBase64String(key);
        }
    }
}
