using AutoMapper;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using OrganistsSchedule.Application;

namespace OrganistsSchedule.WebApi.Controllers;

[Route("v1/parametersSchedule")]
public class ParameterScheduleController(IParameterScheduleService serviceBase, IMapper mapper, IAuthService authService) 
    : ControllerBase<ParameterSchedule, 
        ParameterScheduleDto, 
        ParameterSchedulePagedAndSortedRequest,
        ParameterScheduleCreateUpdateDto, 
        ParameterScheduleCreateUpdateDto>(serviceBase, mapper, authService)
{
    protected override string ReadPolicy => "read:parameter-schedule";
    protected override string UpdatePolicy => "update:parameter-schedule";
    protected override string CreatePolicy => "create:parameter-schedule";
    protected override string DeletePolicy => "delete:parameter-schedule";
}