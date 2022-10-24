using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Domain
{
    [Table("Authors")]
    public class Author
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [EmailAddress]
        public string Email { get; set; }

        // Optional
        public string Address { get; set; }
        public City City { get; set; }
        public State State { get; set; }
        public string ZipCode { get; set; }
    }
}
