using System.Linq.Expressions;
using OrganistsSchedule.Application.Services;

namespace OrganistsSchedule.Application.Interfaces;

public interface ICrudServiceBase<TDto, TEntity>
{
    Task<PagedResultDto<TDto>> GetAllDtoAsync();
    Task<TDto> GetDtoByIdAsync(long id);
    Task<List<TEntity>> GetAllAsync();
    Task<TEntity> GetByIdAsync(long id);
    Task<TEntity> CreateAsync(TDto dto);
    Task<TEntity> UpdateAsync(TDto dto, long id);
    Task<TEntity> DeleteAsync(long id);
}