using Microsoft.AspNetCore.Mvc;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Application.Services;

namespace OrganistsSchedule.WebApi.Controllers;

[ApiController]
public abstract class ControllerBase<TDto, TEntity>(ICrudServiceBase<TDto, TEntity> serviceBase) 
    : Controller, IControllerBase<TDto, TEntity>
    where TDto : class
    where TEntity : class
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
    public virtual async Task<TDto> CreateAsync(TDto dto)
    {
        return await serviceBase.CreateAsync(dto);
    }

    [HttpPut("{id:long}")]
    public virtual async Task<TDto> UpdateAsync(TDto dto)
    {
        if (dto is null)
        {
            throw new ArgumentNullException(nameof(dto));
        }
        return await serviceBase.UpdateAsync(dto);
    }

    [HttpDelete("{id:long}")]
    public virtual async Task<TDto> DeleteAsync(int id)
    {
        return await serviceBase.DeleteAsync(id);
    }
}