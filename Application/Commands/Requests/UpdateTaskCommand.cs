using MediatR;

namespace WebAppTaskManager.Application.Commands.Requests
{
    public class UpdateTaskCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; }
    }
}
