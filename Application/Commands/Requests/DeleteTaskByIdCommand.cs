using MediatR;

namespace WebAppTaskManager.Application.Commands.Requests
{
    public class DeleteTaskByIdCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeleteTaskByIdCommand(Guid id)
        {
            Id = id;
        }
    }
}