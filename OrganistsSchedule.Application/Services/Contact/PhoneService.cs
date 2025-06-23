using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Application.Services;

public class PhoneService(
    IPhoneRepository<PhonePagedAndSortedRequest> repository, 
    IUnitOfWork unitOfWork) 
    : CrudServiceBase<Phone, 
            PhonePagedAndSortedRequest>(repository, unitOfWork),
        IPhoneService
{

}