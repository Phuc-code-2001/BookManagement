using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Users
{
    public class CreateAppUser
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [StringLength(32, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string Source { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime? HireDate { get; set; }

        // Relationship
        public int RoleId { get; set; } = 1;
        public int PublisherId { get; set; }

    }
}
