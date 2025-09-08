using ToDoApi.Application.Errors;
using ToDoApi.Application.Services.Users;
using ToDoApi.Domain.Entities;
using ToDoApi.Infrastructure.DataBaseContext;
using MediatR;
using Task = ToDoApi.Domain.Entities.Task;

namespace ToDoApi.Application.Users.AssignTask
{
    /// <summary>
    /// Handles the <see cref="AssignTaskCommand"/>, assign a task by the user's ID.
    /// </summary>
    /// <param name="context">Db Context</param>
    /// <param name="userServices">Service to retrieve data from the Db Context</param>
    public class AssignTaskCommandHandler(IApplicationDbContext context, IUserServices userServices) : IRequestHandler<AssignTaskCommand, AssignTaskCommandResult>
    {
        public async Task<AssignTaskCommandResult> Handle(AssignTaskCommand command, CancellationToken cancellationToken)
        {
            var user = await userServices.GetByIdAsync(command.Id, cancellationToken);

            if (user is null)
                throw new NotFoundError($"{nameof(User)} with ID {command.Id} was not found.");

            var task = await userServices.GetTaskByIdAsync(command.AssignedTaskId, cancellationToken);

            if (task is null)
                throw new NotFoundError($"{nameof(Task)} with ID {command.AssignedTaskId} was not found.");

            user.AssignTask(task);

            await context.SaveAsync(cancellationToken);

            return new AssignTaskCommandResult(user.Id);
        }
    }
}