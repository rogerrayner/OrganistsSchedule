using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.WebApi.Controllers;

[Route("v1/addresses")]
public class AddressController(IAddressService serviceBase, IMapper mapper) 
    : ControllerBase<AddressDto, Address>(serviceBase, mapper)
{
    
}