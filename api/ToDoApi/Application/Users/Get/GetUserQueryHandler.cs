using System.Collections.Immutable;
using ToDoApi.Application.Errors;
using ToDoApi.Application.Services.Users;
using ToDoApi.Application.Users.Get._DTO;
using ToDoApi.Domain.Entities;
using Mapster;
using MediatR;

namespace ToDoApi.Application.Users.Get
{
    /// <summary>
    /// Handles the <see cref="GetUserQuery"/>, returns the result with the user's data.
    /// </summary>
    /// <param name="userServices">Service to retrieve data from the Db Context</param>
    public class GetUserQueryHandler(IUserServices userServices) : IRequestHandler<GetUserQuery, GetUserQueryResult>
    {
        public async Task<GetUserQueryResult> Handle(GetUserQuery query, CancellationToken cancellationToken)
        {
            var user = await userServices.GetByIdAsync(query.Id, cancellationToken);

            if (user is null)
                throw new NotFoundError($"{nameof(User)} with ID {query.Id} was not found.");

            var result = new GetUserQueryResult(user.Id)
            {
                User = user.Adapt<UserDto>(),
                Tasks = user.Tasks.Select(t => t.Adapt<TaskDto>()).ToImmutableList()
            };

            return result;
        }
    }
}