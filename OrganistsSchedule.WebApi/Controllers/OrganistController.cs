using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrganistsSchedule.Application;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.WebApi.Controllers;

[Route("v1/organists")]
public class OrganistController(IOrganistService serviceBase, IMapper mapper, IAuthService authService) 
    : ControllerBase<Organist, 
        OrganistDto, 
        OrganistPagedAndSortedRequest,
        OrganistCreateDto, 
        OrganistUpdateDto>(serviceBase, mapper, authService)
{
    protected override string ReadPolicy => "read:organist";
    protected override string UpdatePolicy => "update:organist";
    protected override string CreatePolicy => "create:organist";
    protected override string DeletePolicy => "delete:organist";
}