using NUnit.Framework.Internal;

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

		[Test]
		public async Task Test1()
		{
			var response = await client.GetAsync("WeatherForecast");
			var content = await response.Content.ReadAsStringAsync();
			Assert.Pass();
		}
	}
}