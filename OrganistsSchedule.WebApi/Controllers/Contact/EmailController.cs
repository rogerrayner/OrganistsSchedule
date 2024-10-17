using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.WebApi.Controllers.Contact;

public class EmailController(IEmailService service)
    : ControllerBase<EmailDto, Email>(service)
{
    
}