using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using NSubstitute;
using ToDoList.Api.Application;

namespace ToDoList.Api.Tests {
	internal class CustomWebApplicationFactory : WebApplicationFactory<Program> {
		private string baseApiUrl;
		public AddTaskHandler addTask = Substitute.For<AddTaskHandler>(new object[] { null });

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

			builder.ConfigureServices(services => {
				//SwapSingleton(services, ApiClientsMocks.FileSystemService);
				SwapScoped(services, addTask);
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

		public static void SwapSingleton<TService>(IServiceCollection services, TService service) where TService : class {
			services.RemoveAll(typeof(TService));
			services.AddSingleton<TService>(_ => service);
		}

		public static void SwapScoped<TService>(IServiceCollection services, TService service) where TService : class {
			services.RemoveAll(typeof(TService));
			services.AddScoped<TService>(_ => service);
		}

	}
}
