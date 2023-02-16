using Microsoft.EntityFrameworkCore;
using BugsTrackingSystem.Models;
using BugsTrackingSystem.DAL;
using BugsTrackingSystem.Services;

namespace BugsTrackingSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<BugsResolvingContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Development"));
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddControllers();
            builder.Services.AddScoped<IBugsService, BugsService>();
            builder.Services.AddScoped<IMessagesService, MessagesService>();
            builder.Services.AddScoped<IProjectsService, ProjectsService>();
            builder.Services.AddScoped<IDashboardService, DashboardService>();
            var app = builder.Build();

            app.MapControllers();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix=string.Empty;
                options.DocumentTitle = "My Swagger";
            });

            app.Run();


        }
    }
}