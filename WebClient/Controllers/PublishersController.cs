using Microsoft.AspNetCore.Mvc;

namespace WebClient.Controllers
{
	public class PublishersController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
