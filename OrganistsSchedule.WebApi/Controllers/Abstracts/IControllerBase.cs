using Microsoft.AspNetCore.Mvc;

namespace OrganistsSchedule.WebApi.Controllers;

public interface IControllerBase<TDto, TEntity> 
    where TDto : class
    where TEntity : class
{
    Task<ActionResult<IEnumerable<TDto>>> GetAllAsync();
    Task<ActionResult<TDto>> GetByIdAsync(int id);
    Task<ActionResult<TDto>> CreateAsync(TDto dto);
    Task<ActionResult<TDto>> UpdateAsync(TDto dto);
    Task<ActionResult<TDto>> DeleteAsync(int id);
}