using System.Data;
using AutoMapper;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Exceptions;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Application.Services;

public abstract class CrudServiceBase<TEntity, TDto, TCreateDto, TUpdateDto>(IMapper mapper, 
    IRepositoryBase<TEntity> repository, IUnitOfWork unitOfWork) 
    : ICrudServiceBase<TEntity, TDto, TCreateDto, TUpdateDto>
    where TDto : class
    where TCreateDto : class
    where TUpdateDto : class
    where TEntity : class
{
    public async Task<PagedResultDto<TDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var listEntities = await repository
            .GetAllAsync(cancellationToken);
        
        var totalCount = listEntities.Count();
        var listDtos = mapper.Map<IEnumerable<TDto>>(listEntities);
        
        return new PagedResultDto<TDto>(
            listDtos,
            totalCount);
    }
    public async Task<TDto?> GetByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetByIdAsync(id, cancellationToken);
        var response = mapper.Map<TDto>(entity);

        return response;
    }
    
    public async Task<TDto> CreateAsync(TCreateDto dto, CancellationToken cancellationToken = default)
    {
        try
        {
            var entity = await repository.CreateAsync(mapper.Map<TEntity>(dto), cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            var response = mapper.Map<TDto>(entity);
            return response;
        }
        catch (Exception e)
        {
            throw;
        }
        
    }

    public async Task<TDto> UpdateAsync(TUpdateDto dto, long id, CancellationToken cancellationToken = default)
    {
        try
        {
            var entity = await repository.GetByIdAsync(id, cancellationToken);
            if (entity == null)
                throw new NotFoundException(Messages.Format(Messages.NotFound, nameof(entity)));
            
            mapper.Map(dto, entity);
            entity = await repository.UpdateAsync(entity, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<TDto>(entity);
        }
        catch (Exception e)
        {
            throw;
        }
    }

    public async Task<TDto> DeleteAsync(long id, CancellationToken cancellationToken = default)
    {
        try
        {
            var entity = repository.GetByIdAsync(id, cancellationToken).Result;
            if (entity == null)
                throw new NotFoundException(Messages.Format(Messages.NotFound, nameof(entity)));
            
        
            entity = await repository.DeleteAsync(entity, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<TDto>(entity);
        }
        catch (Exception e)
        {
            throw;
        }
    }
}

public abstract class CrudServiceBase<TEntity, TDto, TCreateDto> 
    : CrudServiceBase<TEntity, TDto, TCreateDto, TCreateDto>, ICrudServiceBase<TEntity, TDto, TCreateDto>
    where TDto : class
    where TCreateDto : class
    where TEntity : class
{
    protected CrudServiceBase(IMapper mapper, IRepositoryBase<TEntity> repository, IUnitOfWork _unitOfWork)
        : base(mapper, repository, _unitOfWork) { }
}

public abstract class CrudServiceBase<TEntity, TDto> 
    : CrudServiceBase<TEntity, TDto, TDto, TDto>, ICrudServiceBase<TEntity, TDto>
    where TDto : class
    where TEntity : class
{
    protected CrudServiceBase(IMapper mapper, IRepositoryBase<TEntity> repository, IUnitOfWork _unitOfWork)
        : base(mapper, repository, _unitOfWork) { }
}