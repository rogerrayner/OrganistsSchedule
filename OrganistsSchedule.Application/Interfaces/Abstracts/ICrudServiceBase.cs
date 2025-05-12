using System.Linq.Expressions;
using OrganistsSchedule.Application.Services;

namespace OrganistsSchedule.Application.Interfaces;

public interface ICrudServiceBase<TDto, TEntity>
{
    Task<PagedResultDto<TDto>> GetAllAsync();
    Task<TDto> GetByIdAsync(long id);
    Task<TDto> CreateAsync(TDto dto);
    Task<TDto> UpdateAsync(TDto dto);
    Task<TDto> DeleteAsync(long id);
}