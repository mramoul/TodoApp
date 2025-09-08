using ToDoApi.Domain.Entities;
using ToDoApi.Infrastructure.DataBaseContext;
using Mapster;
using MediatR;

namespace ToDoApi.Application.Users.Create
{
    /// <summary>
    /// Handles the <see cref="CreateUserCommand"/>, returns the result with the created user's ID.
    /// </summary>
    /// <param name="context">Db Context</param>
    public class CreateUserCommandHandler(IApplicationDbContext context) : IRequestHandler<CreateUserCommand, CreateUserCommandResult>
    {
        public async Task<CreateUserCommandResult> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var user = command.Adapt<User>();

            await context.AppendAsync(user, cancellationToken);
            await context.SaveAsync(cancellationToken);

            return new CreateUserCommandResult(user.Id);
        }
    }
}