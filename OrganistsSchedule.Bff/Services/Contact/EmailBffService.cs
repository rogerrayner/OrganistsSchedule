using AutoMapper;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Bff.Interfaces;
using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Bff.Services;

public class EmailBffService(IMapper mapper, IEmailService service) 
    : CrudBffServiceBase<Email, 
            EmailDto, 
            EmailPagedAndSortedRequest,
            EmailCreateUpdateRequestDto>(mapper, service), 
        IEmailBffService
{
    
}