using ToDoApi.Api.Tasks;
using ToDoApi.Api.Users;

namespace ToDoApi.Api
{
    /// <summary>
    /// This class provides an extension method to register API endpoints in a web application.
    //  It ensures that specific API routes and middleware are added during application startup, simplifying endpoint management.
    /// </summary>
    public static class ApiConfiguration
    {
        public static IApplicationBuilder UseApiEndpoints(this WebApplication application)
        {
            TaskEndpoints.Register(application);
            UserEndpoints.Register(application);

            return application;
        }

        public static IApplicationBuilder UseMiddlewares(this WebApplication application)
        {
            application.UseMiddleware<ExceptionMiddleware>();

            return application;
        }
    }
}