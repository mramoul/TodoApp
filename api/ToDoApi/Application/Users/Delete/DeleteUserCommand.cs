using MediatR;

namespace ToDoApi.Application.Users.Delete
{
    public record DeleteUserCommand(Guid Id) : IRequest<DeleteUserCommandResult>;
}