using System.Net;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Api.Application;

namespace ToDoList.Api.Controllers {
	[ApiController]
	[Route("api/todo")]
	public class ToDoListController : Controller {
		private readonly AddTaskHandler _addTaskHandler;

		public ToDoListController(AddTaskHandler addTaskHandler)
		{
			_addTaskHandler = addTaskHandler;
		}

		[HttpPost("AddTask")]
		public IActionResult AddTask([FromBody]string task)
		{
			_addTaskHandler.Execute(task);

			return Ok();
		}
	}
}
