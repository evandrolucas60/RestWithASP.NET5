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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Ensure the base OnModelCreating is called first
            base.OnModelCreating(modelBuilder);

            // Add initial data to your table
            modelBuilder.Entity<Person>().HasData(
                    new Person { Id = 1, Address = "Recife", FirstName = "Evandro", Gender = "Male", LastName = "Lucas"},
                    new Person { Id = 2, Address = "Jaboatão", FirstName = "Jamerson", Gender = "Male", LastName = "Lucas"},
                    new Person { Id = 3, Address = "Petrolina", FirstName = "Danielly", Gender = "Femele", LastName = "Oliveira"},
                    new Person { Id = 4, Address = "Juazeiro", FirstName = "Lucinea", Gender = "Femele", LastName = "Lucas"},
                    new Person { Id = 5, Address = "Recife", FirstName = "Bruno", Gender = "male", LastName = "Lucas"}
                );
        }
    }
}
