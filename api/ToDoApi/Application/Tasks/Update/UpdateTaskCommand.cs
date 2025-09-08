using MediatR;

namespace ToDoApi.Application.Tasks.Update
{
    public class UpdateTaskCommand() : IRequest<UpdateTaskCommandResult>
    {
        public required Guid Id { get; init; }
        public string Title { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public Guid? AssignedUserId { get; init; }
    }
}