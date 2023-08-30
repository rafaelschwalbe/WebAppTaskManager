namespace WebAppTaskManager.Data.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        IEnumerable<Domain.Entities.Task> GetAllTasks();
        Domain.Entities.Task GetTaskById(Guid id);
        void CreateTask(Domain.Entities.Task task);
        void UpdateTask(Domain.Entities.Task task);
        void DeleteTask(Guid id);
    }
}
