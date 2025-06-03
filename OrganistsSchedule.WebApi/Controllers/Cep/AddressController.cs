using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrganistsSchedule.Application;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.WebApi.Controllers;

[Route("v1/addresses")]
public class AddressController(IAddressService serviceBase, IMapper mapper, IAuthService authService) 
    : ControllerBase<Address, 
        AddressDto, 
        AddressPagedAndSortedRequest,
        AddressCreateUpdateDto, 
        AddressCreateUpdateDto>(serviceBase, mapper, authService)
{
    protected override string ReadPolicy => "read:address";
    protected override string UpdatePolicy => "update:address";
    protected override string CreatePolicy => "create:address";
    protected override string DeletePolicy => "delete:address";
}