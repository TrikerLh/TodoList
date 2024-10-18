
using ToDoList.Api.Domain;
using ToDoList.Api.Models;

namespace ToDoList.Api.Application;
public class AddTaskHandler
{
	private readonly TaskRepository _repository;

	public AddTaskHandler(TaskRepository repository)
	{
		_repository = repository;
	}

	public virtual void Execute(string taskDescription)
	{
		var id = _repository.NextId();
		var task = new ToDoTask(id, taskDescription);
		_repository.Store(task);

	}
}