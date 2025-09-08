using MediatR;

namespace ToDoApi.Application.Tasks.List
{
    public record ListTaskQuery : IRequest<ListTaskQueryResult>;
}