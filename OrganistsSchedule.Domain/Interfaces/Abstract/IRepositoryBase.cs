using System.Linq.Expressions;
using Microsoft.VisualBasic;
using OrganistsSchedule.Application.Interfaces;

namespace OrganistsSchedule.Domain.Interfaces;

public interface IRepositoryBase<TEntity>
{
    Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken);
    IQueryable<TEntity> CreateFilteredQuery();
    Task<TEntity?> GetByIdAsync(long id, CancellationToken cancellationToken);
    Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken);
    Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken);
    Task<TEntity> DeleteAsync(TEntity entity, CancellationToken cancellationToken);
    Task<ICollection<TEntity>> BulkDeleteAsync(ICollection<TEntity> entities, CancellationToken cancellationToken);
    Task<ICollection<TEntity>> BulkUpdateAsync(ICollection<TEntity> entities, CancellationToken cancellationToken);
    Task<ICollection<TEntity>> BulkCreateAsync(ICollection<TEntity> entities, CancellationToken cancellationToken);
    
}