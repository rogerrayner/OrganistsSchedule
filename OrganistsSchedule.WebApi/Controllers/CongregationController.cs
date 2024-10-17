using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.WebApi.Controllers;

public class CongregationController(ICongregationService serviceBase) 
    : ControllerBase<CongregationDto, Congregation>(serviceBase)
{
    
}