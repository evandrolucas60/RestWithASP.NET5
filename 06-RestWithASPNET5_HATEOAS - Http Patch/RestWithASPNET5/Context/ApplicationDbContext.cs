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
        public DbSet<Book> books { get; set; }
        public DbSet<User> users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Ensure the base OnModelCreating is called first
            base.OnModelCreating(modelBuilder);

            // Add initial data to your table
            modelBuilder.Entity<Person>().HasData(
                    new Person { Id = 1, Address = "Recife", FirstName = "Evandro", Gender = "Male", LastName = "Lucas", Enabled = true},
                    new Person { Id = 2, Address = "Jaboatão", FirstName = "Jamerson", Gender = "Male", LastName = "Lucas", Enabled = true },
                    new Person { Id = 3, Address = "Petrolina", FirstName = "Danielly", Gender = "Femele", LastName = "Oliveira", Enabled = true },
                    new Person { Id = 4, Address = "Juazeiro", FirstName = "Lucinea", Gender = "Femele", LastName = "Lucas", Enabled = true },
                    new Person { Id = 5, Address = "Recife", FirstName = "Bruno", Gender = "male", LastName = "Lucas", Enabled = true }
                );
            
            
            modelBuilder.Entity<Book>().HasData(
                    new Book { Id = 1, Author = "Stephen King", Date = new DateTime(2020, 02, 22), Price = 89.8, Title = "IT"},
                    new Book { Id = 2, Author = "Stephen Hawking", Date = new DateTime(2020, 02, 22), Price = 103.89, Title = "A Brief time history"},
                    new Book { Id = 3, Author = "Connan Arthur Doyle", Date = new DateTime(2020, 02, 22), Price = 146.73, Title = "Sherlock Holme - The Baskerville Dog"},
                    new Book { Id = 4, Author = "Edgar Alan Poe", Date = new DateTime(2020, 02, 22), Price = 75.34, Title = "The Crow"},
                    new Book { Id = 5, Author = "Agatha Christie", Date = new DateTime(2020, 02, 22), Price = 91.56, Title = "A Haunting in Vinice"},
                    new Book { Id = 6, Author = "Agatha Christie", Date = new DateTime(2020, 02, 22), Price = 78.62, Title = "A Haunting in Vinice"},
                    new Book { Id = 7, Author = "JJ Tolkien", Date = new DateTime(2020, 02, 22), Price = 52.32, Title = "The Hobbit"},
                    new Book { Id = 8, Author = "Tom Clancy's", Date = new DateTime(2020, 02, 22), Price = 58.76, Title = "Spliter Cell"}
                    
                );


            modelBuilder.Entity<User>().HasData(
                    new User
                    {
                        Id = 1,
                        Username = "evandro",
                        Fullname = "Evandro Lucas da Silva",
                        Password = "240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9",
                        RefreshToken = "",
                        RefreshTokenExpiryTime = DateTime.Now
                    }
                );
        }
    }
}
