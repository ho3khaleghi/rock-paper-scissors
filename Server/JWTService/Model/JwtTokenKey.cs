using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWTService.Model
{
    public class JwtTokenKey
    {
        public int Id { get; set; }
        public string KID { get; set; } = string.Empty; // Unique identifier for the key
        public string SecretKey { get; set; } = string.Empty; // Base64-encoded 32-byte key
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
        public bool IsActive { get; set; }
    }
}
