using FluentAssertions;
using NSubstitute;
using System.Net;
using System.Net.Http.Json;
using ToDoList.Api.Application;
using ToDoList.Api.Controllers;
using ToDoList.Api.Models;
using static System.Net.Mime.MediaTypeNames;

namespace ToDoList.Api.Tests;

[TestFixture]
public class ToDoListControllerTest
{
	private HttpClient client;
	private CustomWebApplicationFactory application;

	[TearDown]
	public void TearDown() {
		if (application != null) {
			application.Dispose();
		}

		if (client != null) {
			client.Dispose();
		}
	}

	[SetUp]
	public void SetUp()
	{
		application = new CustomWebApplicationFactory();
		client = application.CreateHttpClient();
	}

	[Test]
	public async Task ShouldAddTask()
	{
		var addTask = Substitute.For<AddTaskHandler>();
		var taskDescription = "Any Task";
		addTask.Execute(taskDescription).Returns(new ToDoTask());
		

		var response = await client.PostAsJsonAsync("api/todo/addtask", taskDescription);
		
		response.StatusCode.Should().Be(HttpStatusCode.OK);

	}

}