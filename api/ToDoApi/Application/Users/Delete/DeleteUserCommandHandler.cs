using ToDoApi.Application.Errors;
using ToDoApi.Application.Services.Users;
using ToDoApi.Domain.Entities;
using ToDoApi.Infrastructure.DataBaseContext;
using MediatR;

namespace ToDoApi.Application.Users.Delete
{
    /// <summary>
    /// Handles the <see cref="DeleteUserCommand"/>, returns the result's message.
    /// </summary>
    /// <param name="context">Db Context</param>
    /// <param name="userServices">Service to retrieve data from the Db Context</param>
    public class DeleteUserCommandHandler(IApplicationDbContext context, IUserServices userServices) : IRequestHandler<DeleteUserCommand, DeleteUserCommandResult>
    {
        public async Task<DeleteUserCommandResult> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            var user = await userServices.GetByIdAsync(command.Id, cancellationToken);

            if (user is null)
                throw new NotFoundError($"{nameof(User)} with ID {command.Id} was not found.");

            context.Delete(user);
            await context.SaveAsync(cancellationToken);

            return new DeleteUserCommandResult($"{nameof(User)} with ID {command.Id} has been successfully deleted.");
        }
    }
}