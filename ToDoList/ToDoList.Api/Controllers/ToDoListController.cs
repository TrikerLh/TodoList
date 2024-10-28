using Microsoft.AspNetCore.Mvc;
using ToDoList.Api.Application;

namespace ToDoList.Api.Controllers {
	[ApiController]
	[Route("api/todo")]
	public class ToDoListController : Controller {
		private readonly AddTaskHandler _addTaskHandler;
		private readonly MarkTaskCompletedHandler _markTaskCompletedHandler;

		public ToDoListController(AddTaskHandler addTaskHandler, MarkTaskCompletedHandler markTaskCompletedHandler)
		{
			_addTaskHandler = addTaskHandler;
			_markTaskCompletedHandler = markTaskCompletedHandler;
		}

		[HttpPost("AddTask")]
		public IActionResult AddTask([FromBody]string task)
		{
			_addTaskHandler.Execute(task);

			return Ok();
		}

		[HttpPost("MarkTaskComplete")]
		public IActionResult MarkTaskCompleted([FromQuery] int taskId, [FromBody] bool done)
		{
			_markTaskCompletedHandler.Execute(taskId, done);

			return Ok();
		}

	}
}
