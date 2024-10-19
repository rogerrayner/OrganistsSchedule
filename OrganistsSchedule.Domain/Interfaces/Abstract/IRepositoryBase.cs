using System.Linq.Expressions;

namespace OrganistsSchedule.Domain.Interfaces;

public interface IRepositoryBase<TEntity> 
    where TEntity : class
{
    Task<List<TEntity>> GetAllAsync();
    IQueryable<TEntity> CreateFilteredQuery();
    Task<TEntity?> GetByIdAsync(long id);
    Task<TEntity> CreateAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity);
    Task<TEntity> DeleteAsync(TEntity entity);
}