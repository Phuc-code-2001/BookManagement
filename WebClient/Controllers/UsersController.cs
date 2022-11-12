using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using WebApi.DTOs;
using WebApi.Models.Users;

namespace WebClient.Controllers
{
    public class UsersController : Controller
    {

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
        
    }
}
