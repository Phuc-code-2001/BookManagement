using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using WebApi.Models.Identities;
using static WebApi.Controllers.IdentityController;

namespace WebClient.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginModel loginModel)
        {

            if(!ModelState.IsValid)
            {
                return View(loginModel);
            }

            HttpClient client = new HttpClient();
            StringContent body = new StringContent(JsonConvert.SerializeObject(loginModel), System.Text.Encoding.UTF8, "application/json");
            string url = "https://localhost:44310/api/Identity/RequiredToken";

            var response = client.PostAsync(url, body).Result;
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string raw = response.Content.ReadAsStringAsync().Result;
                HttpContext.Session.SetString("authentication", raw);
                return RedirectToAction("Index", "Home");
            }

            var message = response.Content.ReadAsStringAsync().Result;
            ViewData["ApiMessage"] = message;
            return View(loginModel);
        }
    }
}
