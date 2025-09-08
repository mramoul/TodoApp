using ToDoApi.Application.Users.AssignTask;
using ToDoApi.Application.Users.Create;
using ToDoApi.Application.Users.Delete;
using ToDoApi.Application.Users.Get;
using ToDoApi.Application.Users.List;
using ToDoApi.Application.Users.Update;
using MediatR;

namespace ToDoApi.Api.Users
{
    /// <summary>
    /// Contains the complete User's endpoints registration.
    /// </summary>
    public static class UserEndpoints
    {
        public static WebApplication Register(WebApplication app)
        {
            const string EntityName = "user";

            app.MapPost($"/api/{EntityName}", async (CreateUserCommand command, IMediator mediator) =>
            {
                var bookId = await mediator.Send(command);
                return Results.Created($"api/{EntityName}/{bookId}", bookId);
            })
            .WithTags(EntityName.ToUpper())
            .WithSummary($"Create the {EntityName}.");

            app.MapGet($"/api/{EntityName}", async (Guid id, IMediator mediator) =>
            {
                var author = await mediator.Send(new GetUserQuery(id));
                return Results.Ok(author);
            })
            .WithTags(EntityName.ToUpper())
            .WithSummary($"Retrieves the {EntityName} by ID.");

            app.MapPatch($"/api/{EntityName}", async (UpdateUserCommand command, IMediator mediator) =>
            {
                var result = await mediator.Send(command);
                return Results.NoContent();
            })
            .WithTags(EntityName.ToUpper())
            .WithSummary($"Update the {EntityName} by ID.");

            app.MapPatch($"/api/{EntityName}-assign-task", async (AssignTaskCommand command, IMediator mediator) =>
            {
                var result = await mediator.Send(command);
                return Results.NoContent();
            })
         .WithTags(EntityName.ToUpper())
         .WithSummary($"Assign a task to the {EntityName} by ID.");

            app.MapDelete($"/api/{EntityName}", async (Guid id, IMediator mediator) =>
            {
                var result = await mediator.Send(new DeleteUserCommand(id));
                return Results.Ok(result.Message);
            })
            .WithTags(EntityName.ToUpper())
            .WithSummary($"Delete the {EntityName} by ID.");

            app.MapGet($"/api/{EntityName}-list", async (IMediator mediator) =>
            {
                var listBooks = await mediator.Send(new ListUserQuery());
                return Results.Ok(listBooks);
            })
            .WithTags(EntityName.ToUpper())
            .WithSummary($"Retrieves all {EntityName}s.");

            return app;
        }
    }
}