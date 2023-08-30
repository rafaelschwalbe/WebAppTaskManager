using MediatR;
using WebAppTaskManager.Application.Commands.Requests;
using WebAppTaskManager.Data.Repositories.Interfaces;

namespace WebAppTaskManager.Application.Handlers
{
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, bool>
    {
        private readonly ITaskRepository _taskRepository;

        public UpdateTaskCommandHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public Task<bool> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = _taskRepository.GetTaskById(request.Id);
            if (task is null) { return Task.FromResult(false); }

            task.Description = request.Description;
            task.EndDate = request.EndDate.HasValue ? request.EndDate.Value.ToString() : task.EndDate;
            task.Title = request.Title;
            task.Status = request.Status;

            _taskRepository.UpdateTask(task);

            return Task.FromResult(true);
        }
    }
}
