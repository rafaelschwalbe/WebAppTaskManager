using MediatR;
using WebAppTaskManager.Application.Queries.Responses;

namespace WebAppTaskManager.Application.Queries.Requests
{
    public class GetTaskByIdQuery : IRequest<TaskDetailsResponse>
    {
        public Guid Id { get; set; }

        public GetTaskByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
