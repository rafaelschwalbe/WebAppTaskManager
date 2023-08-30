namespace WebAppTaskManager.Domain.Entities
{
    public class Task
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CreationDate { get; set; }
        public string EndDate { get; set; }
        public string Status { get; set; }
    }
}
