using ToDoList.Api.Models;

namespace ToDoList.Api.Domain;

public interface TaskRepository
{
	public Task<int>NextId();
	public void Store(ToDoTask task);
	public Task<ToDoTask> Retrieve(int taskId);
	void MarkAsCompleted(ToDoTask task);
}