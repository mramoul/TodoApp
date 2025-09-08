using MediatR;

namespace ToDoApi.Application.Tasks.Get
{
    public record GetTaskQuery(Guid Id) : IRequest<GetTaskQueryResult>;
}
