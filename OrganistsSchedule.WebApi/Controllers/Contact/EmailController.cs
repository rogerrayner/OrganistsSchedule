using AutoMapper;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;

using Microsoft.AspNetCore.Mvc;
using OrganistsSchedule.Application;

namespace OrganistsSchedule.WebApi.Controllers;

[Route("v1/emails")]
public class EmailController(IEmailService service, IMapper mapper, IAuthService authService)
    : ControllerBase<Email, 
        EmailDto, 
        EmailPagedAndSortedRequest,
        EmailCreateUpdateRequestDto, 
        EmailCreateUpdateRequestDto>(service, mapper, authService)
{
    
    protected override string ReadPolicy => "read:email";
    protected override string UpdatePolicy => "update:email";
    protected override string CreatePolicy => "create:email";
    protected override string DeletePolicy => "delete:email";
    
    [NonAction]
    public override Task<ActionResult<EmailDto>> UpdateAsync(EmailCreateUpdateRequestDto dto, long id, CancellationToken cancellationToken = default)
    {
        return base.UpdateAsync(dto, id, cancellationToken);
    }
}