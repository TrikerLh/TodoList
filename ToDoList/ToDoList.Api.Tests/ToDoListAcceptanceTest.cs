using System.Net;
using System.Net.Http.Json;
using System.Text;
using FluentAssertions;

namespace ToDoList.Api.Tests {
	[TestFixture]
	public class ToDoListAcceptanceTest
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
		public void Setup() {
			application = new CustomWebApplicationFactory();
			client = application.CreateHttpClient();
		}

		[Ignore("Example")]
		[Test]
		public async Task ExampleTest()
		{
			var response = await client.GetAsync("WeatherForecast");
			var content = await response.Content.ReadAsStringAsync();
			response.StatusCode.Should().Be(HttpStatusCode.OK);
		}

		[Test]
		public async Task shouldAllowAddingTaskCompleteAndRetrieveTheList()
		{
			var taskDescription = "Write a test that fails";
			await client.PostAsJsonAsync("api/todo/addtask", taskDescription); // esta es la forma que le pasa algo por el body
			taskDescription = "Write Production code that makes the test pass";
			await client.PostAsync("todo", new StringContent(taskDescription, Encoding.UTF8, "application/json"));
			taskDescription = "Refactor if there is opportunity";
			await client.PostAsync("todo", new StringContent(taskDescription, Encoding.UTF8, "application/json"));
			var requestUri = "todo/1";
			await client.PatchAsync(requestUri, new StringContent("done", Encoding.UTF8, "application/json"));

			var response = await client.GetAsync("todo");

			var content = await response.Content.ReadAsStringAsync();
			var expectedList = new List<string> //cambiar esto a un objeto cuando sepa de que va la cosa
			{
				"[X] 1. Write a test that fails",
				"[ ] 2. Write Production code that makes the test pass",
				"[ ] 3. Refactor if there is opportunity"
			};

			response.StatusCode.Should().Be(HttpStatusCode.OK);
			content.Should().BeEquivalentTo(expectedList.ToString());


		}
	}
}