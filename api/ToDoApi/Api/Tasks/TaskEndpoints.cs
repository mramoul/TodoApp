using ToDoApi.Application.Tasks.AssignUser;
using ToDoApi.Application.Tasks.Create;
using ToDoApi.Application.Tasks.Delete;
using ToDoApi.Application.Tasks.Get;
using ToDoApi.Application.Tasks.List;
using ToDoApi.Application.Tasks.Update;
using ToDoApi.Application.Tasks.UpdateStatus;
using MediatR;

namespace ToDoApi.Api.Tasks
{
    /// <summary>
    /// Contains the complete Task's endpoints registration.
    /// </summary>
    public static class TaskEndpoints
    {

        public static WebApplication Register(WebApplication app)
        {
            const string EntityName = "task";

            app.MapPost($"/api/{EntityName}", async (CreateTaskCommand command, IMediator mediator) =>
            {
                var authorId = await mediator.Send(command);
                return Results.Created($"api/{EntityName}/{authorId}", authorId);
            })
            .WithTags(EntityName.ToUpper())
            .WithSummary($"Create the {EntityName}.");

            app.MapGet($"/api/{EntityName}", async (Guid id, IMediator mediator) =>
            {
                var author = await mediator.Send(new GetTaskQuery(id));
                return Results.Ok(author);
            })
            .WithTags(EntityName.ToUpper())
            .WithSummary($"Retrieves the {EntityName} by ID.");

            app.MapGet($"/api/{EntityName}-list", async (IMediator mediator) =>
            {
                var listAuthors = await mediator.Send(new ListTaskQuery());
                return Results.Ok(listAuthors);
            })
            .WithTags(EntityName.ToUpper())
            .WithSummary($"Retrieves all {EntityName}s.");

            app.MapPatch($"/api/{EntityName}", async (UpdateTaskCommand command, IMediator mediator) =>
            {
                var result = await mediator.Send(command);
                return Results.NoContent();
            })
            .WithTags(EntityName.ToUpper())
            .WithSummary($"Update the {EntityName} by ID.");

            app.MapPatch($"/api/{EntityName}-update-status", async (UpdateStatusCommand command, IMediator mediator) =>
            {
                var result = await mediator.Send(command);
                return Results.NoContent();
            })
            .WithTags(EntityName.ToUpper())
            .WithSummary($"Update a status of the {EntityName} by ID.");

            app.MapPatch($"/api/{EntityName}-assign-user", async (AssignUserCommand command, IMediator mediator) =>
           {
               var result = await mediator.Send(command);
               return Results.NoContent();
           })
           .WithTags(EntityName.ToUpper())
           .WithSummary($"Assing a user to the {EntityName} by ID.");

            app.MapDelete($"/api/{EntityName}", async (Guid id, IMediator mediator) =>
            {
                var result = await mediator.Send(new DeleteTaskCommand(id));
                return Results.Ok(result.Message);
            })
            .WithTags(EntityName.ToUpper())
            .WithSummary($"Delete the {EntityName} by ID.");

            return app;
        }
    }
}