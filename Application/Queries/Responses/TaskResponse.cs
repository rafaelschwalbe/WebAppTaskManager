namespace WebAppTaskManager.Application.Queries.Responses
{
    public class TaskResponse
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string CreationDate { get; set; }
        public string EndDate { get; set; }
        public string Status { get; set; }
    }
}
