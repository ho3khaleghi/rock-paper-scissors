
using Microsoft.AspNetCore.Mvc;
using RockPaperScissors.Service.Queue;
using RockPaperScissors.Service.Queue.Dto;

namespace RockPaperScissors.Api.Controllers
{
    public class QueueController(ILogger<QueueController> logger, IQueueServiceWrapper queueService)
        : ApiControllerBase(logger)
    {
        [HttpPost("Join")]
        public async Task<ActionResult> JoinQueue(JoinQueueDto joinQueue)
        {
            var result = await queueService.JoinQueueAsync(joinQueue);
            return Ok(result);
        }
        
        [HttpPost("Leave")]
        public async Task<ActionResult> LeaveQueue(LeaveQueueDto leaveQueue)
        {
            var result = await queueService.LeaveQueueAsync(leaveQueue);
            return Ok(result);
        }
    }
}
