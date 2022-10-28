using DataLayer.Domain;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Authors
{
    public class CreateAuthor
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required]
        public string Phone { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        // Optional
        public string Address { get; set; }
        public City City { get; set; }
        public State State { get; set; }
        public string ZipCode { get; set; }
    }
}
