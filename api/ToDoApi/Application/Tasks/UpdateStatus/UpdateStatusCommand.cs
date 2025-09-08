using MediatR;

namespace ToDoApi.Application.Tasks.UpdateStatus
{
    public class UpdateStatusCommand() : IRequest<UpdateStatusCommandResult>
    {
        public required Guid Id { get; init; }
        public required string Status { get; init; }
    }
}