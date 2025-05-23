using AutoMapper;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;

using Microsoft.AspNetCore.Mvc;

namespace OrganistsSchedule.WebApi.Controllers;

[Route("v1/emails")]
public class EmailController(IEmailService service, IMapper mapper)
    : ControllerBase<Email, EmailDto, EmailCreateUpdateRequestDto, EmailCreateUpdateRequestDto>(service, mapper)
{
    [NonAction]
    public override Task<EmailDto> UpdateAsync(EmailCreateUpdateRequestDto dto, long id)
    {
        return base.UpdateAsync(dto, id);
    }
}