using ToDoApi.Application.Services;
using ToDoApi.Application.Services.Tasks;
using MediatR;
using ToDoApi.Application.Services.Users;
using Mapster;
using ToDoApi.Application.Tasks;

namespace ToDoApi.Application
{
    /// <summary>
    /// This class provides an extension method to register the application related services in the web application.
    //  It ensures that specific Application DI are added during application startup, simplifying application layer management.
    /// </summary>
    public static class ApplicationConfiguration
    {
        public static WebApplicationBuilder AddApplicationServices(this WebApplicationBuilder builder)
        {
            AddMediator(builder);
            AddServices(builder);
            AddMappers(builder);

            return builder;
        }

        private static void AddMediator(WebApplicationBuilder builder)
        {
            builder.Services.AddMediatR(typeof(Program).Assembly);
        }

        private static void AddServices(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped(typeof(IBaseServices<>), typeof(BaseServices<>));
            builder.Services.AddMapster();

            // Task
            builder.Services.AddScoped<ITaskServices, TaskServices>();

            // User
            builder.Services.AddScoped<IUserServices, UserServices>();
        }

        private static void AddMappers(WebApplicationBuilder builder)
        {
            // Task
            TaskMappingConfig.RegisterMappings();

            // User
        }
    }
}