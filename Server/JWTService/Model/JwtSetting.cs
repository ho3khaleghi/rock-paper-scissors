namespace JWTService.Model
{
    public class JwtSetting
    {
        public JwtSecretKey? ActiveSecretKey { get; set; }
        public JwtSecretKey? OldSecretKey { get; set; }
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public int AccessTokenExpiration { get; set; }
        public int RefreshTokenExpiration { get; set; }
    }
}
