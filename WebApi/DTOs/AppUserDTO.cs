using DataLayer.Domain;
using System;

namespace WebApi.DTOs
{
    public class AppUserDTO
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Source { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public string FullName { get; set; }

        public string HireDate { get; set; }

        // Relationship
        public AppRole Role { get; set; }
        public PublisherDTO Publisher { get; set; }
    }
}
