using MediatR;

namespace ToDoApi.Application.Users.Get
{
    public record GetUserQuery(Guid Id) : IRequest<GetUserQueryResult>;
}