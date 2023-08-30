using MediatR;
using WebAppTaskManager.Application.Commands.Requests;
using WebAppTaskManager.Data.Repositories.Interfaces;

namespace WebAppTaskManager.Application.Handlers
{
    public class DeleteTaskByIdCommandHandler : IRequestHandler<DeleteTaskByIdCommand, bool>
    {
        private readonly ITaskRepository _taskRepository;

        public DeleteTaskByIdCommandHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public Task<bool> Handle(DeleteTaskByIdCommand request, CancellationToken cancellationToken)
        {
            var task = _taskRepository.GetTaskById(request.Id);
            if (task is null) { return Task.FromResult(false); }

            _taskRepository.DeleteTask(request.Id);

            return Task.FromResult(true);
        }
    }
}
