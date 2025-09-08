using ToDoApi.Application.Errors;
using ToDoApi.Application.Services.Tasks;
using ToDoApi.Domain.Entities;
using ToDoApi.Infrastructure.DataBaseContext;
using Mapster;
using MediatR;
using Task = ToDoApi.Domain.Entities.Task;

namespace ToDoApi.Application.Tasks.Create
{
    /// <summary>
    /// Handles the <see cref="CreateTaskCommand"/>, returns the result with the created task's ID.
    /// </summary>
    /// <param name="context">Db Context</param>
    public class CreateTaskCommandHandler(IApplicationDbContext context, ITaskServices taskServices) : IRequestHandler<CreateTaskCommand, CreateTaskCommandResult>
    {
        public async Task<CreateTaskCommandResult> Handle(CreateTaskCommand command, CancellationToken cancellationToken)
        {
            User? user = null;

            if (command.AssignedUserId != null)
            {
                user = await taskServices.GetUserByIdAsync((Guid)command.AssignedUserId, cancellationToken);

                if (user is null)
                    throw new NotFoundError($"{nameof(User)} with ID {command.AssignedUserId} was not found.");
            }

            var task = command.Adapt<Task>();
            task.AssignUser(user);

            await context.AppendAsync(task, cancellationToken);
            await context.SaveAsync(cancellationToken);

            return new CreateTaskCommandResult(task.Id);
        }
    }
}