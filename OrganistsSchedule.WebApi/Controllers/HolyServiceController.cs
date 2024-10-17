using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.WebApi.Controllers;

public class HolyServiceController(IHolyServiceService serviceBase) 
    : ControllerBase<HolyServiceDto, HolyService>(serviceBase)
{
    
}