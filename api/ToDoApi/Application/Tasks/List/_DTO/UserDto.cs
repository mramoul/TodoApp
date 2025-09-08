namespace ToDoApi.Application.Tasks.List._DTO;

public record UserDto
{
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
}