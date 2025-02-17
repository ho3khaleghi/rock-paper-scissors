using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using JWTService.Model;

namespace JWTService
{
    public class UserTokenRepository
    {
        private readonly ConcurrentDictionary<User, ClaimsIdentity> _tokens
            = new ConcurrentDictionary<User, ClaimsIdentity>();
        public UserTokenRepository() { }
    }
}
