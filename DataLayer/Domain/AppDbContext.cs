using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Domain
{
    public class AppDbContext : DbContext
    {

        IConfiguration _configuration;

        public AppDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(_configuration.GetConnectionString("Default")
                    , b => b.MigrationsAssembly("WebApi"));
            }
        }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<AppRole> Roles { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookAuthor> BookAuthorSet { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            AppRole[] roleSystems = new AppRole[]
            {
                new AppRole()
                {
                    Id = 1,
                    Description = "Customer"
                },
                new AppRole()
                {
                    Id = 2,
                    Description = "Admin"
                },
            };

            modelBuilder.Entity<AppRole>().HasData(roleSystems);



        }

    }
}
