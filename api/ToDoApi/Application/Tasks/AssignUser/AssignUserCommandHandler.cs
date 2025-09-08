using ToDoApi.Application.Errors;
using ToDoApi.Application.Services.Tasks;
using ToDoApi.Domain.Entities;
using ToDoApi.Infrastructure.DataBaseContext;
using MediatR;
using Task = ToDoApi.Domain.Entities.Task;

namespace ToDoApi.Application.Tasks.AssignUser
{
    /// <summary>
    /// Handles the <see cref="AssignUserCommand"/>, assign user with the updated task's ID.
    /// </summary>
    /// <param name="context">Db Context</param>
    /// <param name="taskServices">Service to retrieve data from the Db Context</param>
    public class AssignUserCommandHandler(IApplicationDbContext context, ITaskServices taskServices) : IRequestHandler<AssignUserCommand, AssignUserCommandResult>
    {
        public async Task<AssignUserCommandResult> Handle(AssignUserCommand command, CancellationToken cancellationToken)
        {
            var task = await taskServices.GetByIdAsync(command.Id, cancellationToken);

            if (task is null)
                throw new NotFoundError($"{nameof(Task)} with ID {command.Id} was not found.");

            var user = await taskServices.GetUserByIdAsync((Guid)command.UserId, cancellationToken);

            if (user is null)
                throw new NotFoundError($"{nameof(User)} with ID {command.UserId} was not found.");

            task.AssignUser(user);

            await context.SaveAsync(cancellationToken);

            return new AssignUserCommandResult(task.Id);
        }
    }
}