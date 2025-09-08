using ToDoApi.Application.Tasks.Get._DTO;

namespace ToDoApi.Application.Tasks.Get
{
    public record GetTaskQueryResult
    {
        public Guid Id { get; init; }
        public string Title { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public string Status { get; init; } = string.Empty;
        public UserDto? AssignedUser { get; init; }
    }
}