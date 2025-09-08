using ToDoApi.Application.Errors;
using ToDoApi.Application.Services.Tasks;
using ToDoApi.Infrastructure.DataBaseContext;
using MediatR;
using Task = ToDoApi.Domain.Entities.Task;

namespace ToDoApi.Application.Tasks.Delete
{
    /// <summary>
    /// Handles the <see cref="DeleteTaskCommand"/>, returns the result's message.
    /// </summary>
    /// <param name="context">Db Context</param>
    /// <param name="taskServices">Service to retrieve data from the Db Context</param>
    public class DeleteTaskCommandHandler(IApplicationDbContext context, ITaskServices taskServices) : IRequestHandler<DeleteTaskCommand, DeleteTaskCommandResult>
    {
        public async Task<DeleteTaskCommandResult> Handle(DeleteTaskCommand command, CancellationToken cancellationToken)
        {
            var task = await taskServices.GetByIdAsync(command.Id, cancellationToken);

            if (task is null)
                throw new NotFoundError($"{nameof(Task)} with ID {command.Id} was not found.");

            context.Delete(task);
            await context.SaveAsync(cancellationToken);

            return new DeleteTaskCommandResult($"{nameof(Task)} with ID {command.Id} has been successfully deleted.");
        }
    }
}