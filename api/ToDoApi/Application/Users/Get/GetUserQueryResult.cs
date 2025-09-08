using System.Collections.Immutable;
using ToDoApi.Application.Users.Get._DTO;

namespace ToDoApi.Application.Users.Get
{
    public record GetUserQueryResult(Guid Id)
    {
        public required UserDto User { get; set; }
        public ImmutableList<TaskDto>? Tasks { get; init; }
    }
}