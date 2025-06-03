using AutoMapper;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Application.Services.Requests;
using OrganistsSchedule.Domain.Exceptions;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Application.Services;

public abstract class CrudServiceBase<TEntity, TDto, TRequestDto, TCreateDto, TUpdateDto>(IMapper mapper, 
    IRepositoryBase<TEntity> repository, IUnitOfWork unitOfWork) 
    : ICrudServiceBase<TEntity, TDto, TRequestDto, TCreateDto, TUpdateDto>
    where TDto : class
    where TCreateDto : class
    where TUpdateDto : class
    where TEntity : class
    where TRequestDto : PagedAndSortedRequestDto
{

    public virtual async Task<PagedResultDto<TDto>> GetAllAsync(
        TRequestDto request, 
        CancellationToken cancellationToken,
        ISpecification<TEntity>? specification = null)
    {
        var listEntities = await repository.GetAllAsync(request, cancellationToken, specification);
        var totalCount = await repository.CountAsync(request, cancellationToken, specification);
        var listDtos = mapper.Map<IEnumerable<TDto>>(listEntities);

        return new PagedResultDto<TDto>(listDtos, totalCount);
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

public abstract class CrudServiceBase<TEntity, TDto, TRequestDto, TCreateDto> 
    : CrudServiceBase<TEntity, TDto, TRequestDto, TCreateDto, TCreateDto>, ICrudServiceBase<TEntity, TDto, TRequestDto, TCreateDto>
    where TDto : class
    where TCreateDto : class
    where TEntity : class
    where TRequestDto : PagedAndSortedRequestDto
{
    protected CrudServiceBase(IMapper mapper, IRepositoryBase<TEntity> repository, IUnitOfWork _unitOfWork)
        : base(mapper, repository, _unitOfWork) { }
}

public abstract class CrudServiceBase<TEntity, TDto, TRequestDto> 
    : CrudServiceBase<TEntity, TDto, TRequestDto, TDto, TDto>, ICrudServiceBase<TEntity, TDto, TRequestDto>
    where TDto : class
    where TEntity : class
    where TRequestDto : PagedAndSortedRequestDto
{
    protected CrudServiceBase(IMapper mapper, IRepositoryBase<TEntity> repository, IUnitOfWork _unitOfWork)
        : base(mapper, repository, _unitOfWork) { }
}