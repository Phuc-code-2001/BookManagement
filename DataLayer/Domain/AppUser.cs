using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Domain
{
    [Table("Users")]
    [Index(nameof(Email), IsUnique = true, Name = "Ix_Email")]
    public class AppUser
    {
        [Key]
        public int Id { get; set; }
        
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [StringLength(32, MinimumLength = 6)]
        public string Password { get; set; }
        
        [Required]
        public string Source { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        
        public string FullName => $"{FirstName} {MiddleName} {LastName}";

        public DateTime? HireDate { get; set; }

        // Relationship
        [ForeignKey(nameof(AppRole))]
        public int RoleId { get; set; }
        public AppRole Role { get; set; }


        [ForeignKey(nameof(Publisher))]
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }

    }
}
