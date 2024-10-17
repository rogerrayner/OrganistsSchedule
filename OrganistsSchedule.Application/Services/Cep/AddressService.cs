using AutoMapper;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Application.Services;

public class AddressService(IMapper mapper, IAddressRepository repository) 
    : CrudServiceBase<AddressDto, Address>(mapper, repository), 
        IAddressService
{
    
}