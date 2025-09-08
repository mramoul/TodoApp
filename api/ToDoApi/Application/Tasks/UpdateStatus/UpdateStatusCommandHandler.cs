using ToDoApi.Application.Errors;
using ToDoApi.Application.Services.Tasks;
using ToDoApi.Infrastructure.DataBaseContext;
using Mapster;
using MediatR;
using Task = ToDoApi.Domain.Entities.Task;

namespace ToDoApi.Application.Tasks.UpdateStatus
{
    /// <summary>
    /// Handles the <see cref="UpdateStatusCommandResult"/>, update the status by the task's ID.
    /// </summary>
    /// <param name="context">Db Context</param>
    /// <param name="taskServices">Service to retrieve data from the Db Context</param>
    public class CreateTaskCommandHandler(IApplicationDbContext context, ITaskServices taskServices) : IRequestHandler<UpdateStatusCommand, UpdateStatusCommandResult>
    {
        public async Task<UpdateStatusCommandResult> Handle(UpdateStatusCommand command, CancellationToken cancellationToken)
        {
            var task = await taskServices.GetByIdAsync(command.Id, cancellationToken);

            if (task is null)
                throw new NotFoundError($"{nameof(Task)} with ID {command.Id} was not found.");

            var newTask = command.Adapt<Task>();
            task.UpdateStatus(newTask.Status);

            await context.SaveAsync(cancellationToken);

            return new UpdateStatusCommandResult(task.Id);
        }
    }
}