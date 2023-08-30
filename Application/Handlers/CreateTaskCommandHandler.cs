using MediatR;
using WebAppTaskManager.Application.Commands.Requests;
using WebAppTaskManager.Data.Repositories.Interfaces;

namespace WebAppTaskManager.Application.Handlers
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, bool>
    {
        private readonly ITaskRepository _taskRepository;

        public CreateTaskCommandHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public Task<bool> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Task task = new Domain.Entities.Task
            {
                Id = Guid.NewGuid(),
                CreationDate = DateTime.Now,
                Description = request.Description,
                Status = "Pendente",//criar constante
                Title = request.Title
            };
            _taskRepository.CreateTask(task);

            return Task.FromResult(true);
        }
    }
}
