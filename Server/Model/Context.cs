using Core.Kernel.DataAccess.Context;
using Microsoft.Extensions.Logging;

namespace RockPaperScissors.Model
{
    public class Context(ILogger<EfCoreContext> logger) : EfCoreContext(logger)
    {
    }
}
