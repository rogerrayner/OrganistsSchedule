using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Application.Services;

namespace OrganistsSchedule.WebApi.Controllers;

public interface IControllerBase<TDto, TCreateDto, TUpdateDto>
{
    Task<PagedResultDto<TDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<TDto> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<TDto> CreateAsync(TCreateDto dto, CancellationToken cancellationToken = default);
    Task<TDto> UpdateAsync(TUpdateDto dto, long id, CancellationToken cancellationToken = default);
    Task<TDto> DeleteAsync(int id, CancellationToken cancellationToken = default);
}

public interface IControllerBase<TDto, TCreateDto>
    : IControllerBase<TDto, TCreateDto, TCreateDto>
{
}

public interface IControllerBase<TDto>
    : IControllerBase<TDto, TDto, TDto>
{
}