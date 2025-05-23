using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Application.Services;

namespace OrganistsSchedule.WebApi.Controllers;

public interface IControllerBase<TDto, TCreateDto, TUpdateDto>
{
    Task<PagedResultDto<TDto>> GetAllAsync();
    Task<TDto> GetByIdAsync(int id);
    Task<TDto> CreateAsync(TCreateDto dto);
    Task<TDto> UpdateAsync(TUpdateDto dto, long id);
    Task<TDto> DeleteAsync(int id);
}

public interface IControllerBase<TDto, TCreateDto>
    : IControllerBase<TDto, TCreateDto, TCreateDto>
{
}

public interface IControllerBase<TDto>
    : IControllerBase<TDto, TDto, TDto>
{
}