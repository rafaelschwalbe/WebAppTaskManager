using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAppTaskManager.Application.Commands.Requests;

namespace WebAppTaskManager.Controllers
{
    [ApiController]
    [Route("v1/tasks")]
    public class TaskController : ControllerBase
    {
        [HttpPost]
        public Task<bool> Create([FromServices] IMediator mediator, [FromBody]CreateTaskCommand command) 
        {
            return mediator.Send(command);
        }
    }
}
