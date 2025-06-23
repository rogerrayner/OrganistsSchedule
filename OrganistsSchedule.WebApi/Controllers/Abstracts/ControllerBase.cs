using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Bff.Interfaces;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.WebApi.Controllers;

[ApiController]
public abstract class ControllerBase<
    TEntity,
    TDto,
    TRequest,
    TCreateDto, 
    TUpdateDto>(ICrudBffServiceBase<TEntity, 
                    TDto,
                    TRequest, 
                    TCreateDto, 
                    TUpdateDto> serviceBase, IAuthService authService) 
    : Controller, IControllerBase<TDto,
        TRequest,
        TCreateDto, 
        TUpdateDto>
    where TDto : class
    where TCreateDto : class
    where TUpdateDto : class
    where TEntity: class 
    where TRequest: class, IPagedAndSortedRequest
{
    
    protected virtual string ReadPolicy => null;
    protected virtual string UpdatePolicy => null;
    protected virtual string CreatePolicy => null;
    protected virtual string DeletePolicy => null;
    
    
    private async Task<bool> IsAuthorized(string policy, CancellationToken cancellationToken)
    {
        return true;
        return await authService.IsAuthorized(User,
            HttpContext
                .RequestServices
                .GetRequiredService<IAuthorizationService>(),
            [ReadPolicy], cancellationToken);
    }
    
    [HttpGet]
    public virtual async Task<ActionResult<PagedResultDto<TDto>>> GetAllAsync([FromQuery] TRequest request, CancellationToken cancellationToken = default)
    {
        var authorized = await IsAuthorized(ReadPolicy, cancellationToken);
        if (!authorized)
            return Forbid();

        var response = await serviceBase.GetAllAsync(request, cancellationToken);
        if (response == null)
            return NotFound();

        return Ok(response);
    }

    [HttpGet("{id:long}")]
    public virtual async Task<ActionResult<TDto>> GetByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        var authorized = await IsAuthorized(ReadPolicy, cancellationToken);
        if (!authorized)
        {
            return Forbid();
                
        }
        
        return await serviceBase.GetByIdAsync(id, cancellationToken);
    }

    [HttpPost]
    public virtual async Task<ActionResult<TDto>> CreateAsync([FromBody] TCreateDto dto, CancellationToken cancellationToken = default)
    {
        var authorized = await IsAuthorized(CreatePolicy, cancellationToken);
        if (!authorized)
        {
            return Forbid();
                
        }
        return await serviceBase.CreateAsync(dto, cancellationToken);
    }

    [HttpPut("{id:long}")]
    public virtual async Task<ActionResult<TDto>> UpdateAsync([FromBody] TUpdateDto dto, 
        long id, 
        CancellationToken cancellationToken = default)
    {
        var authorized = await IsAuthorized(UpdatePolicy, cancellationToken);
        if (!authorized)
        {
            return Forbid();
                
        }
        
        return await serviceBase.UpdateAsync(dto, id, cancellationToken);
    }

    [HttpDelete("{id:long}")]
    public virtual async Task<ActionResult<TDto>> DeleteAsync(int id, 
        CancellationToken cancellationToken = default)
    {
        var authorized = await IsAuthorized(DeletePolicy, cancellationToken);
        if (!authorized)
        {
            return Forbid();
                
        }
        
        return await serviceBase.DeleteAsync(id, cancellationToken);
    }
}