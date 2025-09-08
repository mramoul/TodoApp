using ToDoApi.Application.Errors;
using ToDoApi.Application.Services.Tasks;
using ToDoApi.Application.Tasks.List._DTO;
using Mapster;
using MediatR;
using Task = ToDoApi.Domain.Entities.Task;
using System.Collections.Immutable;

namespace ToDoApi.Application.Tasks.List
{
    /// <summary>
    /// Handles the <see cref="ListTaskQuery"/>, returns the result with the list of tasks data.
    /// </summary>
    /// <param name="taskServices">Service to retrieve data from the Db Context</param>
    /// <param name="mapper">Maps the DB source data to the result representation</param>
    public class ListTaskQueryHandler(ITaskServices taskServices) : IRequestHandler<ListTaskQuery, ListTaskQueryResult>
    {
        public async Task<ListTaskQueryResult> Handle(ListTaskQuery query, CancellationToken cancellationToken)
        {
            var tasks = await taskServices.GetListAsync(cancellationToken);

            if (tasks is null)
                throw new NotFoundError($"No {nameof(Task)}s were found.");

            var result = new ListTaskQueryResult()
            {
                TasksList = tasks.Select(t => t.Adapt<TaskDto>()).ToImmutableList()
            };

            return result;
        }
    }
}