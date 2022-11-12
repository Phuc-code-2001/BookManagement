using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Identities
{
    public class LoginModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [JsonProperty("email")]
        public string Email { get; set; }
        
        [Required]
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
