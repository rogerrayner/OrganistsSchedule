using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;

using Microsoft.AspNetCore.Mvc;

namespace OrganistsSchedule.WebApi.Controllers;

[Route("v1/countries")]
public class CountryController(ICountryService serviceBase) 
    : ControllerBase<CountryDto, Country>(serviceBase)
{
    
}