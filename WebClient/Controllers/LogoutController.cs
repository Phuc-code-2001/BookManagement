using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebClient.Extentions;

namespace WebClient.Controllers
{
    public class LogoutController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            SessionManager.Logout(HttpContext);
            return RedirectToAction("Index", "Home");
        }
    }
}
