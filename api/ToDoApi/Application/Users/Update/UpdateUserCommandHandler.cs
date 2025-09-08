using ToDoApi.Application.Errors;
using ToDoApi.Application.Services.Users;
using ToDoApi.Domain.Entities;
using ToDoApi.Infrastructure.DataBaseContext;
using Mapster;
using MediatR;

namespace ToDoApi.Application.Users.Update
{
    /// <summary>
    /// Handles the <see cref="UpdateUserCommand"/>, returns the result with the updated user's ID.
    /// </summary>
    /// <param name="context">Db Context</param>
    /// <param name="userServices">Service to retrieve data from the Db Context</param>
    public class CreateUserCommandHandler(IApplicationDbContext context, IUserServices userServices) : IRequestHandler<UpdateUserCommand, UpdateUserCommandResult>
    {
        public async Task<UpdateUserCommandResult> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            var user = await userServices.GetByIdAsync(command.Id, cancellationToken);

            if (user is null)
                throw new NotFoundError($"{nameof(User)} with ID {command.Id} was not found.");

            var newUser = command.Adapt<User>();
            user.Update(newUser);

            await context.SaveAsync(cancellationToken);

            return new UpdateUserCommandResult(user.Id);
        }
    }
}