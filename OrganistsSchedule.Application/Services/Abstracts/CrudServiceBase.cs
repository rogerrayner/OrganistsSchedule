using AutoMapper;
using OrganistsSchedule.Application.Interfaces;
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
        using var transaction = unitOfWork.BeginTransaction();
        try
        {
            var entity = await repository.CreateAsync(mapper.Map<TEntity>(dto), cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            transaction.Commit();
            
            var response = mapper.Map<TDto>(entity);
            return response;
        }
        catch (Exception e)
        {
            transaction.Rollback();
            throw e;
        }
        
    }

    public async Task<TDto> UpdateAsync(TUpdateDto dto, long id, CancellationToken cancellationToken = default)
    {
        using var transaction = unitOfWork.BeginTransaction();
        try
        {
            var entity = await repository.GetByIdAsync(id, cancellationToken);
            if (entity == null)
                throw new Exception("Entity not found");

            var dtoType = typeof(TUpdateDto);
            var entityType = entity.GetType();

            foreach (var prop in dtoType.GetProperties())
            {
                var value = prop.GetValue(dto);

                // Se for lista, só atualiza se não for nulo e tiver itens
                if (typeof(System.Collections.IEnumerable).IsAssignableFrom(prop.PropertyType) 
                    && prop.PropertyType != typeof(string))
                {
                    if (value is System.Collections.IEnumerable enumerable && value != null)
                    {
                        var enumerator = enumerable.GetEnumerator();
                        if (!enumerator.MoveNext())
                            continue; // Lista vazia, não atualiza
                    }
                    else
                    {
                        continue; // Nulo, não atualiza
                    }
                }
                else
                {
                    if (value == null)
                        continue;

                    if (prop.PropertyType.IsValueType &&
                        Equals(value, Activator.CreateInstance(prop.PropertyType)))
                        continue;
                }

                var entityProp = entityType.GetProperty(prop.Name);
                if (entityProp != null && entityProp.CanWrite)
                {
                    entityProp.SetValue(entity, value);
                }
            }

            entity = await repository.UpdateAsync(entity, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            transaction.Commit();
            return mapper.Map<TDto>(entity);
        }
        catch (Exception e)
        {
            transaction.Rollback();
            throw;
        }
    }

    public async Task<TDto> DeleteAsync(long id, CancellationToken cancellationToken = default)
    {
        using var transaction = unitOfWork.BeginTransaction();
        try
        {
            var entity = repository.GetByIdAsync(id, cancellationToken).Result;
            if (entity == null)
            {
                throw new Exception("Entity not found");
            }
        
            entity = await repository.DeleteAsync(entity, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            transaction.Commit();
            return mapper.Map<TDto>(entity);
        }
        catch (Exception e)
        {
            transaction.Rollback();
            throw e;
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