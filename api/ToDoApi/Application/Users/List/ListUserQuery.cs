using MediatR;

namespace ToDoApi.Application.Users.List
{
    public record ListUserQuery : IRequest<ListUserQueryResult>;
}
