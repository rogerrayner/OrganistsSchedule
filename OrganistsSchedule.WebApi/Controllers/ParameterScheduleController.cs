using OrganistsSchedule.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using OrganistsSchedule.Bff.Interfaces;

namespace OrganistsSchedule.WebApi.Controllers;

[Route("v1/parametersSchedule")]
public class ParameterScheduleController(IParameterScheduleBffService serviceBase, 
    IAuthService authService): Controller 

{

}