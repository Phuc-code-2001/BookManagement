using Microsoft.AspNetCore.Mvc;

namespace WebClient.Controllers
{
    public class AuthorsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
