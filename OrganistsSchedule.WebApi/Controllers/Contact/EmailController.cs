using AutoMapper;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;

using Microsoft.AspNetCore.Mvc;

namespace OrganistsSchedule.WebApi.Controllers;

[Route("v1/emails")]
public class EmailController(IEmailService service, IMapper mapper)
    : ControllerBase<EmailDto, Email>(service, mapper)
{
    
}