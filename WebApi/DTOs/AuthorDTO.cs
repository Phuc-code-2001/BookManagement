using System.ComponentModel.DataAnnotations;

namespace WebApi.DTOs
{
    public class AuthorDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";

        public string Phone { get; set; }
        public string Email { get; set; }

        // Optional
        public string Address { get; set; }
        public TypeResponse City { get; set; }
        public TypeResponse State { get; set; }
        public string ZipCode { get; set; }
    }
}
