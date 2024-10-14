using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;

namespace ToDoList.Api.Tests {
	internal class CustomWebApplicationFactory : WebApplicationFactory<Program> {
		private string baseApiUrl;

		protected override void ConfigureWebHost(IWebHostBuilder builder)
		{
			var integrationConfig = new ConfigurationBuilder()
				.AddJsonFile("testsettings.json", optional: false)
				.AddEnvironmentVariables()
				.Build();
			baseApiUrl = integrationConfig["ApiUrl"];


			builder.ConfigureAppConfiguration(configurationBuilder =>
			{
				configurationBuilder.AddConfiguration(integrationConfig);
			});
		}

		public HttpClient CreateHttpClient()
		{
			var messageHandler = Server.CreateHandler();
			var client = new HttpClient(messageHandler)
			{
				BaseAddress = new Uri(baseApiUrl)
			};
			return client;
		}

	}
}
