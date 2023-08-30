using Dapper;
using Microsoft.Data.Sqlite;

namespace WebAppTaskManager.Data
{
    public class DatabaseBootstrap : IDatabaseBootstrap
    {
        private readonly DatabaseConfig databaseConfig;

        public DatabaseBootstrap(DatabaseConfig databaseConfig)
        {
            this.databaseConfig = databaseConfig;
        }

        public void Setup()
        {
            using var connection = new SqliteConnection(databaseConfig.Name);

            var table = connection.Query<string>("SELECT name FROM sqlite_master WHERE type='table' AND (name = 'task');");
            var tableName = table.FirstOrDefault();
            if (!string.IsNullOrEmpty(tableName) && (tableName == "task"))
                return;

            connection.Execute("CREATE TABLE task ( " +
                               "id TEXT(37) PRIMARY KEY," +
                               "title TEXT(200) NOT NULL," +
                               "description TEXT(1000) NOT NULL," +
                               "creationdate TEXT(25) NOT NULL," +
                               "enddate TEXT(25)," +
                               "status TEXT(25) NOT NULL" +                                
                               ");");
        }
    }
}
