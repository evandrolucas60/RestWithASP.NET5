using Microsoft.EntityFrameworkCore;
using RestWithASPNET5.Context;
using RestWithASPNET5.Services;
using RestWithASPNET5.Services.Implementations;

namespace RestWithASPNET5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            //Setting a connectioString
            var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");

            //Add a DbContext as a service
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

            //versioning API
            builder.Services.AddApiVersioning();

            //Add a Dependencie Injection To IPersonService Interface
            builder.Services.AddScoped<IPersonService, PersonServiceImplementation>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}