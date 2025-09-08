using ToDoApi.Domain;
using ToDoApi.Infrastructure.DataBaseContext;

namespace ToDoApi.Application.Services
{
    public class BaseServices<TEntity>(IApplicationDbContext dbContext) : IBaseServices<TEntity> where TEntity : Entity
    {
        /// <inheritdoc />
        Task<TEntity?> IBaseServices<TEntity>.GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var entity = dbContext.RetrieveAsync<TEntity>(id, cancellationToken);
            return entity;
        }

        /// <inheritdoc />
        Task<List<TEntity>> IBaseServices<TEntity>.GetListAsync(CancellationToken cancellationToken)
        {
            return dbContext.ListAsync<TEntity>(cancellationToken)
;
        }
    }
}