using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Bff.Interfaces;

public interface IEmailBffService: ICrudBffServiceBase<Email, 
    EmailDto, 
    EmailPagedAndSortedRequest, 
    EmailCreateUpdateRequestDto>
{

}