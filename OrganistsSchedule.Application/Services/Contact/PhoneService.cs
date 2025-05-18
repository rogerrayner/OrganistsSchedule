using AutoMapper;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Application.Services;

public class PhoneService(IMapper mapper, IPhoneRepository repository, IUnitOfWork unitOfWork) 
    : CrudServiceBase<Phone, PhoneDto, PhoneCreateUpdateRequestDto>(mapper, repository, unitOfWork),
        IPhoneService
{

}