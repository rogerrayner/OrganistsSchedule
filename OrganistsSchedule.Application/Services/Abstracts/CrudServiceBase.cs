using AutoMapper;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Application.Services;

public abstract class CrudServiceBase<TDto, TEntity>(IMapper mapper, IRepositoryBase<TEntity> repository) 
    : ICrudServiceBase<TDto, TEntity>
    where TDto : class
    where TEntity : class
{
    
    public async Task<PagedResultDto<TDto>> GetAllAsync()
    {
        var entityList = await repository
            .GetAllAsync();
        
        var totalCount = entityList.Count;
        var pagedResultDto = new PagedResultDto<TDto>(
            mapper.Map<IEnumerable<TDto>>(entityList), 
            totalCount);

        return pagedResultDto;
    }
    public async Task<TDto?> GetByIdAsync(long id)
    {
        var entity = await repository.GetByIdAsync(id);
        return mapper.Map<TDto>(entity);
    }
    
    public async Task<TDto> CreateAsync(TDto dto)
    {
        return mapper.Map<TDto>(await repository.CreateAsync(mapper.Map<TEntity>(dto)));
    }

    public async Task<TDto> UpdateAsync(TDto dto)
    {
        return mapper.Map<TDto>(await repository.UpdateAsync(mapper.Map<TEntity>(dto)));
    }

    public async Task<TDto> DeleteAsync(long id)
    {
        var entity = repository.GetByIdAsync(id).Result;
        return mapper.Map<TDto>(await repository.DeleteAsync(entity));
    }
}