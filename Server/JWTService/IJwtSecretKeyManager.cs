using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Kernel.Dependency;
using JWTService.Model;

namespace JWTService
{
    public interface IJwtSecretKeyManager : ISingletonDependencyInjection
    {
        JwtSecretKey CurrentActiveSecretKey { get; }

    }
}
