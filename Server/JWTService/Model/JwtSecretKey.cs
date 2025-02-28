namespace JWTService.Model
{
    public class JwtSecretKey
    {
        public Guid KeyId { get; set; } = Guid.Empty; // Unique identifier for the key
        public string SecretKey { get; set; } = string.Empty; // Base64-encoded 32-byte key
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
        public bool IsActive { get; set; }
    }
}
