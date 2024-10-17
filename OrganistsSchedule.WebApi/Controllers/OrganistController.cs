using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.WebApi.Controllers;

public class OrganistController(IOrganistService serviceBase) 
    : ControllerBase<OrganistDto, Organist>(serviceBase)
{
    
}