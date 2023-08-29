namespace WebAppTaskManager.Domain.Entities
{
    public class Task
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; }
    }
}
