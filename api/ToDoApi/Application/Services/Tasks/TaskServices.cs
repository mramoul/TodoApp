using ToDoApi.Domain.Entities;
using ToDoApi.Infrastructure.DataBaseContext;
using Task = ToDoApi.Domain.Entities.Task;

namespace ToDoApi.Application.Services.Tasks
{
    /// <summary>
    /// Defines the service for handling Task entities.
    /// </summary>
    public interface ITaskServices : IBaseServices<Task>
    {
        public Task<User?> GetUserByIdAsync(Guid id, CancellationToken cancellationToken);
    }

    /// <inheritdoc />  
    public class TaskServices(IApplicationDbContext dbContext) : BaseServices<Task>(dbContext), ITaskServices
    {
        private readonly IApplicationDbContext _dbContext = dbContext;

        Task<User?> ITaskServices.GetUserByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var entity = _dbContext.RetrieveAsync<User>(id, cancellationToken);
            return entity;
        }
    }
}