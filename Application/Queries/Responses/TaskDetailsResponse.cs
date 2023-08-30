namespace WebAppTaskManager.Application.Queries.Responses
{
    public class TaskDetailsResponse
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CreationDate { get; set; }
        public string EndDate { get; set; }
        public string Status { get; set; }
    }
}
