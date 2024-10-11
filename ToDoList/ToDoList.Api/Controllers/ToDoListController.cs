using Microsoft.AspNetCore.Mvc;

namespace ToDoList.Api.Controllers {
	[ApiController]
	[Route("[controller]")]
	public class ToDoListController : Controller {
		[HttpPost(Name = "todo")]
		public IActionResult AddTask() {
			throw new NotImplementedException();
		}
	}
}
