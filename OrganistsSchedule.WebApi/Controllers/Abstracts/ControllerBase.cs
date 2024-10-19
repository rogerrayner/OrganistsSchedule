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
    [Route("/api/[controller]/[action]")]
    public async Task<PagedResultDto<TDto>> GetAllAsync()
    {
        return await serviceBase.GetAllAsync();
    }

    [HttpGet]
    [Route("/api/[controller]/[action]")]
    public virtual async Task<TDto> GetByIdAsync(int id)
    {
        return await serviceBase.GetByIdAsync(id);
    }

    [HttpPost]
    [Route("/api/[controller]/[action]")]
    public virtual async Task<TDto> CreateAsync(TDto dto)
    {
        return await serviceBase.CreateAsync(dto);
    }

    [HttpPut]
    [Route("/api/[controller]/[action]/{id}")]
    public virtual async Task<TDto> UpdateAsync(TDto dto)
    {
        return await serviceBase.UpdateAsync(dto);
    }

    [HttpDelete]
    [Route("/api/[controller]/[action]/{id}")]
    public virtual async Task<TDto> DeleteAsync(int id)
    {
        return await serviceBase.DeleteAsync(id);
    }
}