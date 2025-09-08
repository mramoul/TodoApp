using MediatR;

namespace ToDoApi.Application.Tasks.AssignUser
{
    public class AssignUserCommand() : IRequest<AssignUserCommandResult>
    {
        public required Guid Id { get; init; }
        public required Guid UserId { get; init; }
    }
}