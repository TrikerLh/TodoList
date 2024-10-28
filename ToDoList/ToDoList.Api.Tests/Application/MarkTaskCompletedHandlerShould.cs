using FluentAssertions;
using NSubstitute;
using ToDoList.Api.Domain;
using ToDoList.Api.Models;
using ToDoList.Api.Application;

namespace ToDoList.Api.Tests.Application {
	[TestFixture]
	public class MarkTaskCompletedHandlerShould {
		[SetUp]
		public void Setup() {
		}

		[Test]
		public void MarkTaskAsComplete()
		{
			var  taskId = 1;
			var task = Substitute.For<ToDoTask>();
			var taskRepository = Substitute.For<TaskRepository>();
			taskRepository.Retrieve(taskId).Returns(task);
			var markTaskCompletedHandler = new MarkTaskCompletedHandler(taskRepository);

			markTaskCompletedHandler.Execute(taskId, true);

			task.Received().MarkCompleted();
			//taskRepository.Received().MarkAsCompleted(task);
		}
	}
}
