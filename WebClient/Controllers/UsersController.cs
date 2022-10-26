using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using WebApi.DTOs;

namespace WebClient.Controllers
{
    public class UsersController : Controller
    {

        HttpClient _client;

        public UsersController(HttpClient client)
        {
            _client = client;
        }

        public IActionResult Index()
        {

            return View();
        }
        
    }
}
