using MediatR;

namespace ToDoApi.Application.Tasks.Create
{
    public class CreateTaskCommand : IRequest<CreateTaskCommandResult>
    {
        public string Title { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public Guid? AssignedUserId { get; init; }
    }
}
