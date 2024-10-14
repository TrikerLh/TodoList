using ToDoList.Api.Models;

namespace ToDoList.Api.Application;

public interface AddTaskHandler
{
    public ToDoTask Execute(string task);
}

public class AddTaskFileHandler : AddTaskHandler
{
	public ToDoTask Execute(string task)
	{
		throw new NotImplementedException();
	}
}