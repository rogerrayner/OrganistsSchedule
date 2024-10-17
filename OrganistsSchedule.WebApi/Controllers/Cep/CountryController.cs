using Microsoft.AspNetCore.Mvc;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.WebApi.Controllers;

public class CountryController(ICountryService serviceBase) 
    : ControllerBase<CountryDto, Country>(serviceBase)
{
    
}