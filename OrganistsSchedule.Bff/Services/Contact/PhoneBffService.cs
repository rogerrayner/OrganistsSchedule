using AutoMapper;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Bff.Interfaces;
using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Bff.Services;

public class PhoneBffService(IMapper mapper, IPhoneService service) 
    : CrudBffServiceBase<Phone, 
            PhoneDto,
            PhonePagedAndSortedRequest,
            PhoneCreateUpdateRequestDto>(mapper, service),
        IPhoneBffService
{

}