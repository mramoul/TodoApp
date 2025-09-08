using ToDoApi.Application.Errors;
using ToDoApi.Application.Services.Tasks;
using ToDoApi.Domain.Entities;
using ToDoApi.Infrastructure.DataBaseContext;
using Mapster;
using MediatR;
using Task = ToDoApi.Domain.Entities.Task;

namespace ToDoApi.Application.Tasks.Update
{
    /// <summary>
    /// Handles the <see cref="UpdateTaskCommand"/>, returns the result with the updated task's ID.
    /// </summary>
    /// <param name="context">Db Context</param>
    /// <param name="taskServices">Service to retrieve data from the Db Context</param>
    public class CreateTaskCommandHandler(IApplicationDbContext context, ITaskServices taskServices) : IRequestHandler<UpdateTaskCommand, UpdateTaskCommandResult>
    {
        public async Task<UpdateTaskCommandResult> Handle(UpdateTaskCommand command, CancellationToken cancellationToken)
        {
            var task = await taskServices.GetByIdAsync(command.Id, cancellationToken);

            if (task is null)
                throw new NotFoundError($"{nameof(Task)} with ID {command.Id} was not found.");

            User? user = null;

            if (command.AssignedUserId != null)
            {
                user = await taskServices.GetUserByIdAsync((Guid)command.AssignedUserId, cancellationToken);

                if (user is null)
                    throw new NotFoundError($"{nameof(User)} with ID {command.AssignedUserId} was not found.");
            }

            var newTask = command.Adapt<Task>();
            newTask.AssignUser(user);

            task.Update(newTask);

            await context.SaveAsync(cancellationToken);

            return new UpdateTaskCommandResult(task.Id);
        }
    }
}