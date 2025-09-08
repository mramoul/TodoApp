using ToDoApi.Application.Tasks.Get;
using ToDoApi.Application.Tasks.Get._DTO;
using ToDoApi.Application.Tasks.UpdateStatus;
using Mapster;
using Task = ToDoApi.Domain.Entities.Task;

namespace ToDoApi.Application.Tasks;

public static class TaskMappingConfig
{
    public static void RegisterMappings()
    {
        TypeAdapterConfig<Task, GetTaskQueryResult>.NewConfig()
          .Map(dest => dest.Status, src => src.Status.ToString())
          .Map(dest => dest.AssignedUser,
               src => src.AssignedUser == null
                   ? null
                   : new UserDto
                   {
                       FirstName = src.AssignedUser.FirstName,
                       LastName = src.AssignedUser.LastName
                   });

        TypeAdapterConfig<UpdateStatusCommand, Task>.NewConfig()
        .Map(dest => dest.Status, src => src.Status != null ? Enum.Parse<StatusType>(src.Status) : StatusType.Void);
    }
}