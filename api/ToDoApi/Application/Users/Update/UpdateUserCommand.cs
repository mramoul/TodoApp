using MediatR;

namespace ToDoApi.Application.Users.Update
{
    public class UpdateUserCommand() : IRequest<UpdateUserCommandResult>
    {
        public required Guid Id { get; init; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}