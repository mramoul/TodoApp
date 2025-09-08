using MediatR;

namespace ToDoApi.Application.Users.Create
{
    public class CreateUserCommand : IRequest<CreateUserCommandResult>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}