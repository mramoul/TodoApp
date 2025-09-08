using System.Collections.Immutable;
using ToDoApi.Application.Errors;
using ToDoApi.Application.Services.Users;
using ToDoApi.Application.Users.List._DTO;
using ToDoApi.Domain.Entities;
using Mapster;
using MediatR;

namespace ToDoApi.Application.Users.List
{
    /// <summary>
    /// Handles the <see cref="ListUserQuery"/>, returns the result with the list of the users.
    /// </summary>
    /// <param name="userServices">Service to retrieve data from the Db Context</param>
    public class ListUserQueryHandler(IUserServices userServices) : IRequestHandler<ListUserQuery, ListUserQueryResult>
    {
        public async Task<ListUserQueryResult> Handle(ListUserQuery query, CancellationToken cancellationToken)
        {
            var users = await userServices.GetListAsync(cancellationToken);

            if (users is null)
                throw new NotFoundError($"No {nameof(User)}s were found.");

            var result = new ListUserQueryResult()
            {
                UsersList = users.Select(t => t.Adapt<UserDto>()).ToImmutableList()
            };

            return result;
        }
    }
}