using Microsoft.EntityFrameworkCore;
using RestWithASPNET5.Context;
using RestWithASPNET5.Business;
using RestWithASPNET5.Business.Implementations;
using RestWithASPNET5.Repository;
using RestWithASPNET5.Repository.Implementations;

namespace RestWithASPNET5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();

            //Log.Logger = new LoggerConfiguration().WriteTo
            //    .Console()
            //    .CreateLogger();


            // Add services to the container.
            builder.Services.AddControllers();

            //Setting a connectioString
            var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");

            //Add a DbContext as a service
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

            //versioning API
            builder.Services.AddApiVersioning();

            //Add a Dependencie Injection To IPersonService Interface
            builder.Services.AddScoped<IPersonBusiness, PersonBusinessImplementation>();
            builder.Services.AddScoped<IPersonRepository, PersonRepositoryImplementation>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();

                //MigrationDatabase(connectionString);
            }

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

        //private static void MigrationDatabase(string connectionString)
        //{
        //    try
        //    {
        //        var evolveConnection = new SqlConnection(connectionString);
        //        var evolve = new Evolve(evolveConnection, msg => Log.Information(msg))
        //        {
        //            Locations = new List<string> { "db/migrations", "db/dataset"},
        //            IsEraseDisabled = true,
        //        };
        //        evolve.Migrate();
        //    }
        //    catch (Exception e)
        //    {
        //        Log.Error("Database migration failed", e);
        //        throw;
        //    }
        //}
    }
}