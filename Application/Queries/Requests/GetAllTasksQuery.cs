using MediatR;
using WebAppTaskManager.Application.Queries.Responses;

namespace WebAppTaskManager.Application.Queries.Requests
{
    public class GetAllTasksQuery : IRequest<IList<TaskResponse>>
    {
    }
}
