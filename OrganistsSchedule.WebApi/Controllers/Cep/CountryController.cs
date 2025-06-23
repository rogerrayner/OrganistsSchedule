using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Bff.Interfaces;

namespace OrganistsSchedule.WebApi.Controllers;

[Route("v1/countries")]
public class CountryController(ICountryBffService serviceBase, IAuthService authService) 
    : ControllerBase<Country, 
        CountryResponseDto,
        CountryPagedAndSortedRequest,
        CountryCreateUpdateRequestDto, 
        CountryCreateUpdateRequestDto>(serviceBase, authService)
{
    protected override string ReadPolicy => "read:country";
    protected override string UpdatePolicy => "update:country";
    protected override string CreatePolicy => "create:country";
    protected override string DeletePolicy => "delete:country";
}