using AutoMapper;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Bff.Interfaces;
using OrganistsSchedule.Domain.Exceptions;
using OrganistsSchedule.Domain.Interfaces;
using OrganistsSchedule.Domain.Utils;

namespace OrganistsSchedule.Bff.Services;

public abstract class CrudBffServiceBase<TEntity, 
    TDto,
    TRequest, 
    TCreateDto, 
    TUpdateDto> (IMapper mapper,
                 ICrudServiceBase<TEntity, TRequest> crudServiceBase)    
        : ICrudBffServiceBase<TEntity, 
            TDto,
            TRequest, 
            TCreateDto, 
            TUpdateDto>
    where TDto : class
    where TCreateDto : class
    where TUpdateDto : class
    where TEntity : class
    where TRequest : class, IPagedAndSortedRequest
{
    public virtual async Task<PagedResultDto<TDto>> GetAllAsync(
        TRequest request,
        CancellationToken cancellationToken = default,
        ISpecification<TEntity>? specification = null)
    {
        var result = await crudServiceBase.GetAllAsync(
            request, 
            cancellationToken, 
            specification);
        
        return new PagedResultDto<TDto>(
            mapper.Map<IEnumerable<TDto>>(result.Items), 
            result.TotalCount
            );
    }

    public virtual async Task<TDto?> GetByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        var entity = await crudServiceBase.GetByIdAsync(id, cancellationToken);
        return mapper.Map<TDto>(entity);
    }

    public virtual async Task<TDto> CreateAsync(TCreateDto dto, CancellationToken cancellationToken = default)
    {
        var mappedEntity = mapper.Map<TEntity>(dto);
        var entity = await crudServiceBase.CreateAsync(mappedEntity, cancellationToken);
        return mapper.Map<TDto>(entity);
    }

    public virtual async Task<TDto> UpdateAsync(TUpdateDto dto, long id, CancellationToken cancellationToken = default)
    {
        var entity = await crudServiceBase.GetByIdAsync(id, cancellationToken);
        if (entity == null)
            ErrorHandler.ThrowNotFoundException(Messages.NotFound, nameof(entity));

        var mappedEntity = mapper.Map(dto, entity);
        entity = await crudServiceBase.UpdateAsync(mappedEntity, id, cancellationToken);
        return mapper.Map<TDto>(entity);
    }

    public virtual async Task<TDto> DeleteAsync(long id, CancellationToken cancellationToken = default)
    {
        var entity = await crudServiceBase.DeleteAsync(id, cancellationToken);
        return mapper.Map<TDto>(entity);
    }
}

public abstract class CrudBffServiceBase<TEntity, TDto, TRequest, TCreateDto>
    : CrudBffServiceBase<TEntity, TDto, TRequest, TCreateDto, TCreateDto>
    where TDto : class
    where TCreateDto : class
    where TEntity : class
    where TRequest : class, IPagedAndSortedRequest
{
    protected CrudBffServiceBase(IMapper mapper, ICrudServiceBase<TEntity, TRequest> crudServiceBase)
        : base(mapper, crudServiceBase) { }
}
public abstract class CrudBffServiceBase<TEntity, TDto, TRequest>
    : CrudBffServiceBase<TEntity, TDto, TRequest, TDto, TDto>
    where TDto : class
    where TEntity : class
    where TRequest: class, IPagedAndSortedRequest
{
    protected CrudBffServiceBase(IMapper mapper, ICrudServiceBase<TEntity, TRequest> crudServiceBase)
        : base(mapper, crudServiceBase) { }
}