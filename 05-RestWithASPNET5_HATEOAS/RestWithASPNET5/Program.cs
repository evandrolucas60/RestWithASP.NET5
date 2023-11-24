using Microsoft.EntityFrameworkCore;
using RestWithASPNET5.Context;
using RestWithASPNET5.Business;
using RestWithASPNET5.Business.Implementations;
using RestWithASPNET5.Repository;
using RestWithASPNET5.Repository.Generic;
using Microsoft.Net.Http.Headers;
using RestWithASPNET5.Hypermedia.Filters;
using RestWithASPNET5.Hypermedia.Enricher;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Rewrite;

namespace RestWithASPNET5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();

            builder.Services.AddCors(options => options.AddDefaultPolicy(builder =>
            {
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            }));

            // Add services to the container.
            builder.Services.AddControllers();

            //Setting a connectioString
            var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");

            //Add a DbContext as a service
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

            //
            builder.Services.AddMvc(options =>
            {
                options.RespectBrowserAcceptHeader = true;

                options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));
                options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("application/xml"));
            }).AddXmlSerializerFormatters();

            var filterOptions = new HyperMediaFilterOptions();
            filterOptions.ContentResponseEnricherList.Add(new PersonEnricher());
            filterOptions.ContentResponseEnricherList.Add(new BookEnricher());

            builder.Services.AddSingleton(filterOptions);

            //versioning API
            builder.Services.AddApiVersioning();

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Rest API's From 0 to Azure with ASP.NET Core 5 and Docker",
                        Version = "v1",
                        Description = "API RESTful developed in course 'Rest API's From 0 to Azure with ASP.NET Core 5 and Docker'",
                        Contact = new OpenApiContact
                        {
                            Name = "Evandro Lucas",
                            Url = new Uri("https://github.com/evandrolucas60")
                        }
                    });
            });

            //Add a Dependencie Injection To IPersonService Interface
            builder.Services.AddScoped<IPersonBusiness, PersonBusinessImplementation>();
            builder.Services.AddScoped<IBookBusiness, BookBusinessImplementation>();
            builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

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

            app.UseRouting();

            app.UseCors();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "Rest API's From 0 to Azure with ASP.NET Core 5 and Docker - v1");
            });

            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);

            app.UseAuthorization();

            app.MapControllers();

            app.MapControllerRoute("DefaultApi", "{controller=values}/v{version=apiVersion}/{id?}");

            app.Run();
        }
    }
}