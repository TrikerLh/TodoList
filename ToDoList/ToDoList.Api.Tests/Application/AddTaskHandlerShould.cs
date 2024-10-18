using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ReceivedExtensions;
using ToDoList.Api.Application;
using ToDoList.Api.Domain;
using ToDoList.Api.Models;

namespace ToDoList.Api.Tests.Application {
	[TestFixture]
	public class AddTaskHandlerShould {
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void AddTasToRepository()
		{
			var taskRepository = Substitute.For<TaskRepository>();
			var taskDescription = "Task Description";
			var addTaskHandler = new AddTaskHandler(taskRepository);
			taskRepository.NextId().Returns(1);

			addTaskHandler.Execute(taskDescription);

			var task = new ToDoTask(1, "Task Description");
			taskRepository.Received(1).Store(task);
		}

	}
}
