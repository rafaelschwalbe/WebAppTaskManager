using MediatR;
using WebAppTaskManager.Application.Queries.Requests;
using WebAppTaskManager.Application.Queries.Responses;
using WebAppTaskManager.Data.Repositories.Interfaces;

namespace WebAppTaskManager.Application.Handlers
{
    public class GetAllTasksQueryHandler : IRequestHandler<GetAllTasksQuery, IList<TaskResponse>>
    {
        private readonly ITaskRepository _taskRepository;

        public GetAllTasksQueryHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public Task<IList<TaskResponse>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
        {
            var tasks = _taskRepository.GetAllTasks().Select(s => new TaskResponse
            {
                CreationDate = s.CreationDate,
                EndDate = s.EndDate,
                Id = s.Id,
                Status = s.Status,
                Title = s.Title
            })
            .OrderByDescending(o => o.CreationDate)
            .ToList();
            return Task.FromResult<IList<TaskResponse>>(tasks);
        }
    }
}
