using System.Linq.Expressions;
using OrganistsSchedule.Application.Interfaces;

namespace OrganistsSchedule.Domain.Interfaces;

public interface IRepositoryBase<TEntity>
{
    Task<List<TEntity>> GetAllAsync();
    IQueryable<TEntity> CreateFilteredQuery();
    Task<TEntity?> GetByIdAsync(long id);
    Task<TEntity> CreateAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity);
    Task<TEntity> DeleteAsync(TEntity entity);
}