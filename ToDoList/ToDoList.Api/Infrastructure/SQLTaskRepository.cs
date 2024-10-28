using System.Data.SqlClient;
using System.Threading.Tasks;
using ToDoList.Api.Domain;
using ToDoList.Api.Models;

namespace ToDoList.Api.Infrastructure
{
    public class SQLTaskRepository : TaskRepository
    {
        private readonly string _connectionString;

        public SQLTaskRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<int> NextId()
        {
	        var nextId = 0;
			using (var connection = new SqlConnection(_connectionString)) {
				await connection.OpenAsync();
				var command = new SqlCommand("SELECT Count(Id) FROM Tasks", connection);

				using (var reader = await command.ExecuteReaderAsync()) {
					if (await reader.ReadAsync())
					{
						nextId = reader.GetInt32(0);
					}
				}
			}
			return nextId + 1;
		}

        public async void Store(ToDoTask task)
        {
	        using (var connection = new SqlConnection(_connectionString))
	        {
		        await connection.OpenAsync();
		        var command = new SqlCommand("INSERT INTO Tasks (Id, Description) VALUES (@Id, @Description)",
			        connection);
		        command.Parameters.AddWithValue("@Id", task.Id);
		        command.Parameters.AddWithValue("@Description", task.Description);

		        await command.ExecuteNonQueryAsync();
	        }
        }

        public async Task<ToDoTask> Retrieve(int taskId)
        {
	        ToDoTask toDoTask = null;

	        using (var connection = new SqlConnection(_connectionString)) {
		        await connection.OpenAsync();
		        var command = new SqlCommand("SELECT Id, Description FROM Tasks WHERE Id = @Id", connection);
		        command.Parameters.AddWithValue("@Id", taskId);

		        using (var reader = await command.ExecuteReaderAsync()) {
			        if (await reader.ReadAsync()) {
				        toDoTask = new ToDoTask (reader.GetInt32(0),reader.GetString(1));
			        }
		        }
	        }

	        return toDoTask;
		}

        public void MarkAsCompleted(ToDoTask task)
        {
	        throw new NotImplementedException();
        }
    }
}
