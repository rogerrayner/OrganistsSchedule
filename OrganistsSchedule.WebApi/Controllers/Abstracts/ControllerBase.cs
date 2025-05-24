using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Application.Services;
using OrganistsSchedule.Domain.Exceptions;

namespace OrganistsSchedule.WebApi.Controllers;

[ApiController]
public abstract class ControllerBase<
    TEntity,
    TDto,
    TCreateDto, 
    TUpdateDto>(ICrudServiceBase<
                TEntity,
                TDto, 
                TCreateDto, 
                TUpdateDto> serviceBase, IMapper mapper) 
    : Controller, IControllerBase<TDto, 
        TCreateDto, 
        TUpdateDto>
    where TDto : class
    where TCreateDto : class
    where TUpdateDto : class
    where TEntity: class 
{
    
    [HttpGet]
    public virtual async Task<PagedResultDto<TDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await serviceBase.GetAllAsync(cancellationToken);
    }

    [HttpGet("{id:long}")]
    public virtual async Task<TDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await serviceBase.GetByIdAsync(id, cancellationToken);
    }

    [HttpPost]
    public virtual async Task<TDto> CreateAsync([FromBody] TCreateDto dto, CancellationToken cancellationToken = default)
    {
        return mapper.Map<TDto>(await serviceBase.CreateAsync(dto, cancellationToken));
    }

    [HttpPut("{id:long}")]
    public virtual async Task<TDto> UpdateAsync([FromBody] TUpdateDto dto, long id, CancellationToken cancellationToken = default)
    {
        if (dto is null)
            throw new BusinessException(Messages.Format(Messages.InvalidField, nameof(dto)));
        
        return mapper.Map<TDto>(await serviceBase.UpdateAsync(dto, id, cancellationToken));
    }

    [HttpDelete("{id:long}")]
    public virtual async Task<TDto> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        return mapper.Map<TDto>(await serviceBase.DeleteAsync(id, cancellationToken));
    }
}