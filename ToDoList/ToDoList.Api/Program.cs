
using ToDoList.Api.Application;
using ToDoList.Api.Domain;
using ToDoList.Api.Infrastructure;

namespace ToDoList.Api {
	public class Program {
		public static void Main(string[] args) {
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			builder.Services.AddScoped<AddTaskHandler>();
			builder.Services.AddScoped<MarkTaskCompletedHandler>();
			builder.Services.AddScoped<TaskRepository>(provider => new SQLTaskRepository(connectionString));

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment()) {
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
