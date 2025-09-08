namespace ToDoApi.Application.Errors
{
    /// <summary>
    /// Defines a custom exception for "Not Found" entity in the DbContext.
    /// </summary>
    /// <param name="message">The associated error message</param>
    public class NotFoundError(string message) : Exception(message);
}

