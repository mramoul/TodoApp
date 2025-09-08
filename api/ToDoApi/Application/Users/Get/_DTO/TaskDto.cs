namespace ToDoApi.Application.Users.Get._DTO;

public class TaskDto
{
    public required Guid Id { get; set; }
    public required string Title { get; set; }

}