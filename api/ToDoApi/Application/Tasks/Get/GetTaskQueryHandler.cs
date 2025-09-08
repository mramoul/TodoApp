using ToDoApi.Application.Errors;
using ToDoApi.Application.Services.Tasks;
using Mapster;
using MediatR;
using Task = ToDoApi.Domain.Entities.Task;

namespace ToDoApi.Application.Tasks.Get
{
    /// <summary>
    /// Handles the <see cref="GetTaskQuery"/>, returns the result with the task's data.
    /// </summary>
    /// <param name="taskServices">Service to retrieve data from the Db Context</param>
    public class GetTaskQueryHandler(ITaskServices taskServices) : IRequestHandler<GetTaskQuery, GetTaskQueryResult>
    {
        public async Task<GetTaskQueryResult> Handle(GetTaskQuery query, CancellationToken cancellationToken)
        {
            var task = await taskServices.GetByIdAsync(query.Id, cancellationToken);

            if (task is null)
                throw new NotFoundError($"{nameof(Task)} with ID {query.Id} was not found.");

            var result = task.Adapt<GetTaskQueryResult>();

            return result;
        }
    }
}
