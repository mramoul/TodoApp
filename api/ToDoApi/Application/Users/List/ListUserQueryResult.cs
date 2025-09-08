using System.Collections.Immutable;
using ToDoApi.Application.Users.List._DTO;

namespace ToDoApi.Application.Users.List
{
    public record ListUserQueryResult()
    {
        public required ImmutableList<UserDto> UsersList { get; init; }
    }
}