using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebClient.Controllers
{
	public class PublishersController : Controller
	{
        [Authorize(Roles = "Admin")]
		public IActionResult Index()
		{
			return View();
		}
	}
}
