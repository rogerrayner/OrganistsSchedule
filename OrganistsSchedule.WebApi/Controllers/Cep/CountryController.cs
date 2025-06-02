using AutoMapper;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;

using Microsoft.AspNetCore.Mvc;
using OrganistsSchedule.Application;

namespace OrganistsSchedule.WebApi.Controllers;

[Route("v1/countries")]
public class CountryController(ICountryService serviceBase, IMapper mapper, IAuthService authService) 
    : ControllerBase<Country, 
        CountryResponseDto, 
        CountryPagedAndSortedRequest,
        CountryCreateUpdateRequestDto, 
        CountryCreateUpdateRequestDto>(serviceBase, mapper, authService)
{
    protected override string ReadPolicy => "read:country";
    protected override string UpdatePolicy => "update:country";
    protected override string CreatePolicy => "create:country";
    protected override string DeletePolicy => "delete:country";
}