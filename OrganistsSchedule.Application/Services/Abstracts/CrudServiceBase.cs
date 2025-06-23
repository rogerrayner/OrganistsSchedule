using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Interfaces;
using OrganistsSchedule.Domain.Interfaces.Results;
using OrganistsSchedule.Domain.Utils;

namespace OrganistsSchedule.Application.Services;

public abstract class CrudServiceBase<TEntity, TRequest>(
    IRepositoryBase<TEntity, TRequest> repository, 
    IUnitOfWork unitOfWork) 
    : ICrudServiceBase<TEntity, TRequest>

    where TEntity : class
    where TRequest : class, IPagedAndSortedRequest
{
    public virtual async Task<IPagedResult<TEntity>> GetAllAsync(
        TRequest request, 
        CancellationToken cancellationToken,
        ISpecification<TEntity>? specification = null)
    {
        return await repository.GetAllAsync(request, cancellationToken, specification);
    }

    public virtual async Task<TEntity?> GetByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        return await repository.GetByIdAsync(id, cancellationToken);
    }
    
    public virtual async Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        try
        {
            entity = await repository.CreateAsync(entity, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return entity;

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }

    public virtual async Task<TEntity> UpdateAsync(TEntity dto, long id, CancellationToken cancellationToken = default)
    {
        try
        {
            var entity = await repository.GetByIdAsync(id, cancellationToken);
            if (entity == null)
                ErrorHandler.ThrowNotFoundException(Messages.NotFound, nameof(entity));
            
            entity = await repository.UpdateAsync(entity, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return entity;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public virtual async Task<TEntity> DeleteAsync(long id, CancellationToken cancellationToken = default)
    {
        try
        {
            var entity = repository.GetByIdAsync(id, cancellationToken).Result;
            if (entity == null)
                ErrorHandler.ThrowNotFoundException(Messages.NotFound, nameof(entity));
            
        
            entity = await repository.DeleteAsync(entity, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return entity;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}