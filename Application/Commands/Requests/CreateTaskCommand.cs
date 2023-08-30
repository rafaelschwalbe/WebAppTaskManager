using MediatR;

namespace WebAppTaskManager.Application.Commands.Requests
{
    public class CreateTaskCommand : IRequest<bool>
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
