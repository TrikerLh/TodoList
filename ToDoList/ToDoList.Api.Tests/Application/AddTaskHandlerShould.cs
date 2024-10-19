using NSubstitute;
using ToDoList.Api.Application;
using ToDoList.Api.Domain;
using ToDoList.Api.Models;

namespace ToDoList.Api.Tests.Application {
	[TestFixture]
	public class AddTaskHandlerShould {
		private const string TaskDescription = "Task Description";
		private const int TaskId = 1;

		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void AddTasToRepository()
		{
			var taskRepository = Substitute.For<TaskRepository>();
			var addTaskHandler = new AddTaskHandler(taskRepository);
			taskRepository.NextId().Returns(TaskId);

			addTaskHandler.Execute(TaskDescription);

			var task = new ToDoTask(TaskId, TaskDescription);
			taskRepository.Received(1).Store(task);
		}

	}
}
