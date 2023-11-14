using Microsoft.EntityFrameworkCore;
using RestWithASPNET5.Model;

namespace RestWithASPNET5.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() { }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Person> persons { get; set; }
    }
}
