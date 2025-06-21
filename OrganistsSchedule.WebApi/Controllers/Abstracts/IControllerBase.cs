using Microsoft.AspNetCore.Mvc;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.WebApi.Controllers;

public interface IControllerBase<TDto,
    TRequest, 
    TCreateDto, 
    TUpdateDto>
    where TRequest : class, IPagedAndSortedRequest
{
    Task<ActionResult<PagedResultDto<TDto>>> GetAllAsync(TRequest request, CancellationToken cancellationToken = default);
    Task<ActionResult<TDto>> GetByIdAsync(long id, CancellationToken cancellationToken = default);
    Task<ActionResult<TDto>> CreateAsync(TCreateDto dto, CancellationToken cancellationToken = default);
    Task<ActionResult<TDto>> UpdateAsync(TUpdateDto dto, long id, CancellationToken cancellationToken = default);
    Task<ActionResult<TDto>> DeleteAsync(int id, CancellationToken cancellationToken = default);
}

public interface IControllerBase<TDto, TRequest, TCreateDto>
    : IControllerBase<TDto, TRequest, TCreateDto, TCreateDto>
    where TRequest : class, IPagedAndSortedRequest
{
}

public interface IControllerBase<TDto, TRequest>
    : IControllerBase<TDto, TRequest, TDto, TDto>
    where TRequest : class, IPagedAndSortedRequest
{
}