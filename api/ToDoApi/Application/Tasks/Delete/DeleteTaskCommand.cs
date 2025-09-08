using MediatR;

namespace ToDoApi.Application.Tasks.Delete
{
    public record DeleteTaskCommand(Guid Id) : IRequest<DeleteTaskCommandResult>;
}
