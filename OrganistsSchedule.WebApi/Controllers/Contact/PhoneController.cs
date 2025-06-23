using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;

using Microsoft.AspNetCore.Mvc;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Bff.Interfaces;

namespace OrganistsSchedule.WebApi.Controllers;

[Route("v1/phones")]
public class PhoneController(IPhoneBffService serviceBase, IAuthService authService) 
    : ControllerBase<Phone, 
        PhoneDto,
        PhonePagedAndSortedRequest,
        PhoneCreateUpdateRequestDto, 
        PhoneCreateUpdateRequestDto>(serviceBase, authService)
{
    protected override string ReadPolicy => "read:phone";
    protected override string UpdatePolicy => "update:phone";
    protected override string CreatePolicy => "create:phone";
    protected override string DeletePolicy => "delete:phone";
    
    [NonAction]
    public override Task<ActionResult<PhoneDto>> UpdateAsync(PhoneCreateUpdateRequestDto dto, long id, CancellationToken cancellationToken = default)
    {
        return base.UpdateAsync(dto, id, cancellationToken);
    }
}