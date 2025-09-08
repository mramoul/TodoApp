using ToDoApi.Domain.Entities;
using ToDoApi.Infrastructure.DataBaseContext;
using Task = ToDoApi.Domain.Entities.Task;

namespace ToDoApi.Application.Services.Users
{
    /// <summary>
    /// Defines the service for handling User entities.
    /// </summary>
    public interface IUserServices : IBaseServices<User>
    {
        public Task<Task?> GetTaskByIdAsync(Guid id, CancellationToken cancellationToken);
    }

    /// <inheritdoc />  
    public class UserServices(IApplicationDbContext dbContext) : BaseServices<User>(dbContext), IUserServices
    {
        private readonly IApplicationDbContext _dbContext = dbContext;

        Task<Task?> IUserServices.GetTaskByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var entity = _dbContext.RetrieveAsync<Task>(id, cancellationToken);
            return entity;
        }
    }
}