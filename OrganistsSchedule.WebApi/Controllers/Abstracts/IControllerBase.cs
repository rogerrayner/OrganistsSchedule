using Microsoft.AspNetCore.Mvc;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Application.Services;
using OrganistsSchedule.Application.Services.Requests;

namespace OrganistsSchedule.WebApi.Controllers;

public interface IControllerBase<TDto, TRequestDto, TCreateDto, TUpdateDto>
{
    Task<ActionResult<PagedResultDto<TDto>>> GetAllAsync(TRequestDto request, CancellationToken cancellationToken = default);
    Task<ActionResult<TDto>> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<ActionResult<TDto>> CreateAsync(TCreateDto dto, CancellationToken cancellationToken = default);
    Task<ActionResult<TDto>> UpdateAsync(TUpdateDto dto, long id, CancellationToken cancellationToken = default);
    Task<ActionResult<TDto>> DeleteAsync(int id, CancellationToken cancellationToken = default);
}

public interface IControllerBase<TDto, TRequestDto,TCreateDto>
    : IControllerBase<TDto, TRequestDto, TCreateDto, TCreateDto>
{
}

public interface IControllerBase<TDto, TRequestDto>
    : IControllerBase<TDto, TRequestDto, TDto, TDto>
{
}