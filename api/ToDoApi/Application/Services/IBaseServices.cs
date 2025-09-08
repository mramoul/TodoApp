using ToDoApi.Domain;

namespace ToDoApi.Application.Services
{
    public interface IBaseServices<TEntity> where TEntity : Entity
    {
        /// <summary>
        /// Retrieve entities from the database by there unique Id.
        /// </summary>
        /// <param name="id">The entity's unique Id</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The desired entity</returns>
        Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieve all entity's records from the database.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The desired entity</returns>
        Task<List<TEntity>> GetListAsync(CancellationToken cancellationToken = default);
    }
}