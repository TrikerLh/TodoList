using ToDoList.Api.Models;

namespace ToDoList.Api.Domain;

public interface TaskRepository
{
	public int NextId();
	public void Store(ToDoTask task);
}