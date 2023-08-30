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
            using var connection = new SqliteConnection(DatabaseConfig.Name);

            var query = "SELECT * FROM task";
            var tasks = connection.Query<Domain.Entities.Task>(query);

            return tasks;
        }

        public Domain.Entities.Task GetTaskById(Guid id)
        {
            using var connection = new SqliteConnection(DatabaseConfig.Name);

            var query = "SELECT * FROM task WHERE id = @Id";
            var task = connection.QuerySingleOrDefault<Domain.Entities.Task>(query, new { Id = id.ToString() });

            return task;
        }

        public void UpdateTask(Domain.Entities.Task task)
        {
            using var connection = new SqliteConnection(DatabaseConfig.Name);
            string query = $"UPDATE task " +
                $"SET title = '{task.Title}', description = '{task.Description}', enddate = '{task.EndDate}', status = '{task.Status}'" +
                $"WHERE id = '{task.Id}';";
            connection.Execute(query);
        }
    }
}
