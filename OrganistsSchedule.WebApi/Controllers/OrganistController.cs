using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.WebApi.Controllers;

[Route("v1/organists")]
public class OrganistController(IOrganistService serviceBase, IMapper mapper) 
    : ControllerBase<OrganistDto, Organist>(serviceBase, mapper)
{
    
}