using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Bff.Interfaces;

public interface IPhoneBffService: ICrudBffServiceBase<Phone, 
    PhoneDto, 
    PhonePagedAndSortedRequest, 
    PhoneCreateUpdateRequestDto>
{

}