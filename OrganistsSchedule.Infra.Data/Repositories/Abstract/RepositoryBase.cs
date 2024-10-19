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
        return await CreateFilteredQuery()
            .ToListAsync();
    }
    
    //TODO retirar comentario
    /*private IQueryable<TEntity> CreateFilteredQueryAsync(Expression<Func<TEntity, bool>> predicate,
        Expression<Func<TEntity, object>>[] includes)
    {
        var query = context.Set<TEntity>().Where(predicate);
        return includes
                .Aggregate(query, 
                (current, includeProperty) => current.Include(includeProperty));
    }*/ 
    
    public virtual IQueryable<TEntity> CreateFilteredQuery()
    {
        return context.Set<TEntity>().AsQueryable();
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