using AutoMapper;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Application.Services;

public abstract class CrudServiceBase<TDto, TEntity>(IMapper mapper, IRepositoryBase<TEntity> repository) 
    : ICrudServiceBase<TDto, TEntity>
    where TDto : class
    where TEntity : class
{
 
    public async Task<PagedResultDto<TDto>> GetAllDtoAsync()
    {
        var entityList = await repository
            .GetAllAsync();
        
        var totalCount = entityList.Count;
        var pagedResultDto = new PagedResultDto<TDto>(
            mapper.Map<IEnumerable<TDto>>(entityList), 
            totalCount);

        return pagedResultDto;
    }
    public async Task<TDto> GetDtoByIdAsync(long id)
    {
        var dto = mapper.Map<TDto>(await repository.GetByIdAsync(id));
        if (dto == null)
        {
            throw new Exception("Dto not found");
        }

        return dto;
    }
    
    public async Task<List<TEntity>> GetAllAsync()
    {
        return await repository
            .GetAllAsync();
    }
    public async Task<TEntity> GetByIdAsync(long id)
    {
        var entity = await repository.GetByIdAsync(id);
        
        if (entity == null)
        {
            throw new Exception("Entity not found");
        }

        return entity;
    }
    
    public async Task<TEntity> CreateAsync(TDto dto)
    {
        return await repository.CreateAsync(mapper.Map<TEntity>(dto));
    }

    public async Task<TEntity> UpdateAsync(TDto dto, long id)
    {
        var entity = await repository.GetByIdAsync(id);
        if (entity == null)
        {
            throw new Exception("Entity not found");
        }
        mapper.Map(dto, entity);
        return await repository.UpdateAsync(entity);
    }

    public async Task<TEntity> DeleteAsync(long id)
    {
        var entity = repository.GetByIdAsync(id).Result;
        if (entity == null)
        {
            throw new Exception("Entity not found");
        }
        
        return await repository.DeleteAsync(entity);
    }
}