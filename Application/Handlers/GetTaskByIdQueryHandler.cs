using MediatR;
using WebAppTaskManager.Application.Queries.Requests;
using WebAppTaskManager.Application.Queries.Responses;
using WebAppTaskManager.Data.Repositories.Interfaces;

namespace WebAppTaskManager.Application.Handlers
{
    public class GetTaskByIdQueryHandler : IRequestHandler<GetTaskByIdQuery, TaskDetailsResponse>
    {
        private readonly ITaskRepository _taskRepository;

        public GetTaskByIdQueryHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public Task<TaskDetailsResponse> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            var task = _taskRepository.GetTaskById(request.Id);

            if(task is null) { return null; }//TODO: melhorar tratamento de erro

            TaskDetailsResponse response = new TaskDetailsResponse
            {
                CreationDate = task.CreationDate,
                Description = task.Description,
                EndDate = task.EndDate,
                Id = task.Id,
                Status = task.Status,
                Title = task.Title
            };

            return Task.FromResult(response);
        }
    }
}
