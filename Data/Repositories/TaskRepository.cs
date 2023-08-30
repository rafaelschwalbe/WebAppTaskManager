using Dapper;
using Microsoft.Data.Sqlite;
using WebAppTaskManager.Data.Repositories.Interfaces;

namespace WebAppTaskManager.Data.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DatabaseConfig DatabaseConfig;

        public TaskRepository(DatabaseConfig databaseConfig)
        {
            DatabaseConfig = databaseConfig;
        }

        public void CreateTask(Domain.Entities.Task task)
        {
            using var connection = new SqliteConnection(DatabaseConfig.Name);
            string query = $"INSERT INTO task(id, title, description, creationdate, enddate, status) " +
                $"VALUES('{Guid.NewGuid().ToString()}', '{task.Title}', '{task.Description}', '{task.CreationDate}', '{task.EndDate}', '{task.Status}');";
            connection.Execute(query);
        }

        public void DeleteTask(Domain.Entities.Task task)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Domain.Entities.Task> GetAllTasks()
        {
            throw new NotImplementedException();
        }

        public Domain.Entities.Task GetTaskById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void UpdateTask(Domain.Entities.Task task)
        {
            throw new NotImplementedException();
        }
    }
}
