using AutoMapper;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Application.Services;

public class EmailService(IMapper mapper, IEmailRepository repository) 
    : CrudServiceBase<EmailDto, Email>(mapper, repository), 
        IEmailService
{
    
}