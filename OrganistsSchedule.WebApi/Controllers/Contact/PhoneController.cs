using AutoMapper;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;

using Microsoft.AspNetCore.Mvc;

namespace OrganistsSchedule.WebApi.Controllers;

[Route("v1/phones")]
public class PhoneController(IPhoneService serviceBase, IMapper mapper) 
    : ControllerBase<Phone, PhoneDto, PhoneCreateUpdateRequestDto, PhoneCreateUpdateRequestDto>(serviceBase, mapper)
{
    [NonAction]
    public override Task<PhoneDto> UpdateAsync(PhoneCreateUpdateRequestDto dto, long id, CancellationToken cancellationToken = default)
    {
        return base.UpdateAsync(dto, id, cancellationToken);
    }
}