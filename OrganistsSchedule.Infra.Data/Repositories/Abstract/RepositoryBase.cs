using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Infra.Data.Repositories;

public abstract class RepositoryBase<TEntity>(DbContext context) 
    : IRepositoryBase<TEntity>
    where TEntity : class
{
    public async Task<List<TEntity>> GetAllAsync()
    {
        return await context.Set<TEntity>()
            .ToListAsync();
    }
    
    public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>>[] includes)
    {
        return await CreateQueryable(predicate, includes)
            .ToListAsync();
    }

    private IQueryable<TEntity> CreateQueryable(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>>[] includes)
    {
        var query = context.Set<TEntity>().Where(predicate);
        return includes
            .Aggregate(query, 
                (current, includeProperty) => current.Include(includeProperty));
    }

    public async Task<TEntity?> GetByIdAsync(long id)
    {
        return await context.Set<TEntity>().FindAsync(id);
    }

    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        context.Set<TEntity>().Add(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        context.Set<TEntity>().Update(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity> DeleteAsync(TEntity entity)
    {
        context.Set<TEntity>().Remove(entity);
        await context.SaveChangesAsync();
        return entity;
    }
}