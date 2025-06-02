using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Application.Services;
using OrganistsSchedule.Application.Services.Requests;
using OrganistsSchedule.Domain.Exceptions;

namespace OrganistsSchedule.WebApi.Controllers;

[ApiController]
public abstract class ControllerBase<
    TEntity,
    TDto,
    TRequestDto,
    TCreateDto, 
    TUpdateDto>(ICrudServiceBase<
                TEntity,
                TDto, 
                TRequestDto,
                TCreateDto, 
                TUpdateDto> serviceBase, IMapper mapper, IAuthService authService) 
    : Controller, IControllerBase<TDto, 
        TRequestDto,
        TCreateDto, 
        TUpdateDto>
    where TDto : class
    where TCreateDto : class
    where TUpdateDto : class
    where TEntity: class 
    where TRequestDto: PagedAndSortedRequestDto
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
    public virtual async Task<ActionResult<PagedResultDto<TDto>>> GetAllAsync([FromQuery] TRequestDto request, CancellationToken cancellationToken = default)
    {
        var authorized = await IsAuthorized(ReadPolicy, cancellationToken);
        if (!authorized)
        {
            return Forbid();
                
        }
        return await serviceBase.GetAllAsync(request, cancellationToken);
    }

    [HttpGet("{id:long}")]
    public virtual async Task<ActionResult<TDto>> GetByIdAsync(int id, CancellationToken cancellationToken = default)
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
        return mapper.Map<TDto>(await serviceBase.CreateAsync(dto, cancellationToken));
    }

    [HttpPut("{id:long}")]
    public virtual async Task<ActionResult<TDto>> UpdateAsync([FromBody] TUpdateDto dto, [FromQuery] long id, CancellationToken cancellationToken = default)
    {
        var authorized = await IsAuthorized(UpdatePolicy, cancellationToken);
        if (!authorized)
        {
            return Forbid();
                
        }
        
        return mapper.Map<TDto>(await serviceBase.UpdateAsync(dto, id, cancellationToken));
    }

    [HttpDelete("{id:long}")]
    public virtual async Task<ActionResult<TDto>> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var authorized = await IsAuthorized(DeletePolicy, cancellationToken);
        if (!authorized)
        {
            return Forbid();
                
        }
        
        return mapper.Map<TDto>(await serviceBase.DeleteAsync(id, cancellationToken));
    }
}