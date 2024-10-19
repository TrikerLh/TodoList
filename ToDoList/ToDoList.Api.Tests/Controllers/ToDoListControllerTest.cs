using FluentAssertions;
using System.Net;
using System.Net.Http.Json;

namespace ToDoList.Api.Tests.Controllers;

[TestFixture]
public class ToDoListControllerTest
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

}