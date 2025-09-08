namespace ToDoApi.Application.Tasks.List._DTO;

public record TaskDto
{
    public required Guid Id { get; init; }
    public string Title { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public string Status { get; init; } = string.Empty;
    public UserDto? AssignedUser { get; init; }
}