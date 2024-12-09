using Microsoft.AspNetCore.Mvc;

namespace RockPaperScissors.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApiControllerBase(ILogger logger) : ControllerBase
    {
        protected ILogger Logger { get => logger; }
        public IActionResult CreateResult<T>(T result)
        {
            return Ok(result);
        }
    }
}
