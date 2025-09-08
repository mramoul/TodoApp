using ToDoApi.Infrastructure.DataBaseContext;
using Microsoft.EntityFrameworkCore;

namespace ToDoApi.Infrastructure
{
    /// <summary>
    /// This class provides an extension method to register the infrastructure related services in the web application.
    //  It ensures that specific Infrastructure DI are added during application startup, simplifying infrastructure management.
    /// </summary>
    public static class InfrastructureConfiguration
    {
        public static WebApplicationBuilder AddInfrastructureServices(this WebApplicationBuilder builder)
        {
            AddCors(builder);
            AddDbContext(builder);
            AddSwagger(builder);

            return builder;
        }

        private static void AddCors(WebApplicationBuilder builder)
        {
            builder.Services.AddCors(options =>
                        {
                            options.AddPolicy("AllowAngularDev", policy =>
                            {
                                policy.WithOrigins("http://localhost:4200")
                                      .AllowAnyHeader()
                                      .AllowAnyMethod();
                            });
                        });
        }

        private static void AddDbContext(WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
        }

        private static void AddSwagger(WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
        }
    }
}