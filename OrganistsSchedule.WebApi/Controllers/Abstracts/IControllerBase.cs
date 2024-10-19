using OrganistsSchedule.Application.Services;

namespace OrganistsSchedule.WebApi.Controllers;

public interface IControllerBase<TDto, TEntity> 
    where TDto : class
    where TEntity : class
{
    Task<PagedResultDto<TDto>> GetAllAsync();
    Task<TDto> GetByIdAsync(int id);
    Task<TDto> CreateAsync(TDto dto);
    Task<TDto> UpdateAsync(TDto dto);
    Task<TDto> DeleteAsync(int id);
}