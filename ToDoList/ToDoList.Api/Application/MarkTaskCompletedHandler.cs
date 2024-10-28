using System.Runtime.InteropServices.JavaScript;
using ToDoList.Api.Domain;

namespace ToDoList.Api.Application {
	public class MarkTaskCompletedHandler {
		private readonly TaskRepository _taskRepository;

		public MarkTaskCompletedHandler(TaskRepository taskRepository)
		{
			_taskRepository = taskRepository;
		}
		public virtual async void Execute(int taskId, bool done)
		{
			var toDoTask = await _taskRepository.Retrieve(taskId);

			toDoTask.MarkCompleted();

		}
	}
}
