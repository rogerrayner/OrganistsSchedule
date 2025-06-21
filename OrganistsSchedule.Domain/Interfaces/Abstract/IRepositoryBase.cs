
using OrganistsSchedule.Domain.Interfaces.Results;

namespace OrganistsSchedule.Domain.Interfaces;

public interface IRepositoryBase<TEntity, TRequest>
    where TEntity : class
{
    Task<IPagedResult<TEntity>> GetAllAsync(TRequest request,
        CancellationToken cancellationToken = default,
        ISpecification<TEntity>? specification = null);

    Task<TEntity?> GetByIdAsync(long id,
        CancellationToken cancellationToken);

    Task<TEntity> CreateAsync(TEntity entity,
        CancellationToken cancellationToken);

    Task<TEntity> UpdateAsync(TEntity entity,
        CancellationToken cancellationToken);

    Task<TEntity> DeleteAsync(TEntity entity,
        CancellationToken cancellationToken);

    Task<IEnumerable<TEntity>> BulkDeleteAsync(IEnumerable<TEntity> entities,
        CancellationToken cancellationToken);

    Task<IEnumerable<TEntity>> BulkUpdateAsync(IEnumerable<TEntity> entities,
        CancellationToken cancellationToken);

    Task<IEnumerable<TEntity>> BulkCreateAsync(IEnumerable<TEntity> entities,
        CancellationToken cancellationToken);
}