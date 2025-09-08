using MediatR;

namespace ToDoApi.Application.Users.AssignTask

{
    public class AssignTaskCommand() : IRequest<AssignTaskCommandResult>
    {
        public required Guid Id { get; init; }
        public required Guid AssignedTaskId { get; set; }
    }
}