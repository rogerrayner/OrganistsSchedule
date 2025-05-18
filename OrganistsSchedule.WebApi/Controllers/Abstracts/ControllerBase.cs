using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Application.Services;

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
    public async Task<PagedResultDto<TDto>> GetAllAsync()
    {
        return await serviceBase.GetAllAsync();
    }

    [HttpGet("{id:long}")]
    public virtual async Task<TDto> GetByIdAsync(int id)
    {
        return await serviceBase.GetByIdAsync(id);
    }

    [HttpPost]
    public virtual async Task<TDto> CreateAsync([FromBody] TCreateDto dto)
    {
        return mapper.Map<TDto>(await serviceBase.CreateAsync(dto));
    }

    [HttpPut("{id:long}")]
    public virtual async Task<TDto> UpdateAsync([FromBody] TUpdateDto dto, long id)
    {
        if (dto is null)
        {
            throw new ArgumentNullException(nameof(dto));
        }
        return mapper.Map<TDto>(await serviceBase.UpdateAsync(dto, id));
    }

    [HttpDelete("{id:long}")]
    public virtual async Task<TDto> DeleteAsync(int id)
    {
        return mapper.Map<TDto>(await serviceBase.DeleteAsync(id));
    }
}