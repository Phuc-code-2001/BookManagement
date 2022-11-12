using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using static WebApi.Controllers.IdentityController;

namespace WebClient.Extentions
{
    public class SessionManager
    {

        public static TokenResponse Authenticate(HttpContext context)
        {
            TokenResponse response = null;
            
            string raw = context.Session.GetString("authentication");
            if(raw != null)
            {
                response = JsonConvert.DeserializeObject<TokenResponse>(raw);
            }

            return response;
        }

        public static void Logout(HttpContext context)
        {
            context.Session.Remove("authentication");
        }
    }
}
