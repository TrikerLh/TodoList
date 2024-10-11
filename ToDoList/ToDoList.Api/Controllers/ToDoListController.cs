using Microsoft.AspNetCore.Mvc;

namespace ToDoList.Api.Controllers {
	[ApiController]
	[Route("api/todo")]
	public class ToDoListController : Controller {
		[HttpPost("AddTask")]
		public IActionResult AddTask([FromBody]string task)
		{
			var holita = task;
			throw new NotImplementedException();
		}
	}
}
