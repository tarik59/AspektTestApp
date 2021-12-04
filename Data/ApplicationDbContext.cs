using Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ApplicationDbContext : DbContext

    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        DbSet<Contact> contacts { set; get; }
        DbSet<Company> companies { set; get; }
        DbSet<Country> countries { set; get; }

    }
}