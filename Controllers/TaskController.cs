using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAppTaskManager.Application.Commands.Requests;
using WebAppTaskManager.Application.Queries.Requests;
using WebAppTaskManager.Application.Queries.Responses;

namespace WebAppTaskManager.Controllers
{
    [ApiController]
    [Route("v1/tasks")]
    public class TaskController : ControllerBase
    {
        [HttpPost]
        public Task<bool> Create([FromServices] IMediator mediator, [FromBody] CreateTaskCommand command) 
        {
            return mediator.Send(command);
        }

        [HttpGet]
        public Task<IList<TaskResponse>> GetAll([FromServices] IMediator mediator)
        {
            return mediator.Send(new GetAllTasksQuery());
        }

        [HttpGet("{id}")]
        public Task<TaskDetailsResponse> GetById([FromServices] IMediator mediator, Guid id)
        {
            return mediator.Send(new GetTaskByIdQuery(id));
        }

        [HttpPut]
        public Task<bool> Update([FromServices] IMediator mediator, [FromBody] UpdateTaskCommand command)
        {
            return mediator.Send(command);
        }
    }
}
