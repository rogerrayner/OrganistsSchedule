using AutoMapper;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;

using Microsoft.AspNetCore.Mvc;

namespace OrganistsSchedule.WebApi.Controllers;

[Route("v1/countries")]
public class CountryController(ICountryService serviceBase, IMapper mapper) 
    : ControllerBase<Country, CountryResponseDto, CountryCreateUpdateRequestDto, CountryCreateUpdateRequestDto>(serviceBase, mapper)
{
    
}