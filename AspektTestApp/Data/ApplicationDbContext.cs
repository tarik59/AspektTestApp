using AspektTestApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
       public DbSet<Contact> contacts { set; get; }
        public DbSet<Company> companies { set; get; }
        public DbSet<Country> countries { set; get; }

    }
}