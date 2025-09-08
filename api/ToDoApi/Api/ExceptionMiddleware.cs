using ToDoApi.Application.Errors;

namespace ToDoApi.Api
{
    /// <summary>
    /// Middleware that handles global exceptions in the API by intercepting errors and returning appropriate HTTP status codes.
    /// </summary>
    /// <param name="next">Http request</param>
    public class ExceptionMiddleware(RequestDelegate next)
    {
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = ex switch
                {
                    NotFoundError => StatusCodes.Status404NotFound,
                    _ => StatusCodes.Status400BadRequest
                };

                await context.Response.WriteAsJsonAsync(new { error = ex.Message });
            }
        }
    }
}