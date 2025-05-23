using AutoMapper;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace OrganistsSchedule.WebApi.Controllers;

[Route("v1/parametersSchedule")]
public class ParameterScheduleController(IParameterScheduleService serviceBase, IMapper mapper) 
    : ControllerBase<ParameterSchedule, ParameterScheduleDto, ParameterScheduleDto, ParameterScheduleDto>(serviceBase, mapper)
{
    
}