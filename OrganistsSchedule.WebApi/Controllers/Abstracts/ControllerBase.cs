using Microsoft.AspNetCore.Mvc;
using OrganistsSchedule.Application.Interfaces;

namespace OrganistsSchedule.WebApi.Controllers;

[ApiController]
public abstract class ControllerBase<TDto, TEntity>(ICrudServiceBase<TDto, TEntity> serviceBase) 
    : Controller, IControllerBase<TDto, TEntity>
    where TDto : class
    where TEntity : class
{
    [HttpGet]
    [Route("/api/[controller]/[action]")]
    public async Task<ActionResult<IEnumerable<TDto>>> GetAllAsync()
    {
        
        return Ok(await serviceBase.GetAllAsync());
    }

    [HttpGet]
    
    [Route("/api/[controller]/[action]")]
    public async Task<ActionResult<TDto>> GetByIdAsync(int id)
    {
        var dto = await serviceBase.GetByIdAsync(id);
        return dto == null ? NotFound() : Ok(dto);
    }

    [HttpPost]
    [Route("/api/[controller]/[action]")]
    public async Task<ActionResult<TDto>> CreateAsync(TDto dto)
    {
        return Ok(await serviceBase.CreateAsync(dto));
    }

    [HttpPut]
    [Route("/api/[controller]/[action]/{id}")]
    public async Task<ActionResult<TDto>> UpdateAsync(TDto dto)
    {
        return Ok(await serviceBase.UpdateAsync(dto));
    }

    [HttpDelete]
    [Route("/api/[controller]/[action]/{id}")]
    public async Task<ActionResult<TDto>> DeleteAsync(int id)
    {
        return Ok(await serviceBase.DeleteAsync(id));
    }
}