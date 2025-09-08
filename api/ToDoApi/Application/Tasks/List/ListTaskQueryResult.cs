using System.Collections.Immutable;
using ToDoApi.Application.Tasks.List._DTO;

namespace ToDoApi.Application.Tasks.List
{
    public record ListTaskQueryResult()
    {
        public required ImmutableList<TaskDto> TasksList { get; init; }
    }
}