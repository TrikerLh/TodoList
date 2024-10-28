using FluentAssertions;
using System.Net;
using System.Net.Http.Json;
using NSubstitute;
using ToDoList.Api.Application;
using System.Threading.Tasks;

namespace ToDoList.Api.Tests.Controllers;

[TestFixture]
public class ToDoListControllerShould
{
    private HttpClient client;
    private CustomWebApplicationFactory application;

    [TearDown]
    public void TearDown()
    {
        if (application != null)
        {
            application.Dispose();
        }

        if (client != null)
        {
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
        var taskDescription = "Any Task";

        var response = await client.PostAsJsonAsync("api/todo/addtask", taskDescription);

        response.StatusCode.Should().Be(HttpStatusCode.OK);

    }

    [Test]
    public async Task MarkTaskCompleted()
    {
	    var taskId = 1;
	    //var markTaskCompleteHandler = Substitute.For<MarkTaskCompletedHandler>(new object[] { null });

		var response = await client.PostAsJsonAsync($"/api/todo/MarkTaskComplete?taskId={taskId}", true);

		//markTaskCompleteHandler.Received().Execute(taskId, true);
		response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

}