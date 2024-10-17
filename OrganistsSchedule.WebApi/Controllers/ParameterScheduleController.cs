using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.WebApi.Controllers;

public class ParameterScheduleController(IParameterScheduleService serviceBase) 
    : ControllerBase<ParameterScheduleDto, ParameterSchedule>(serviceBase)
{
    
}