using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;

using Microsoft.AspNetCore.Mvc;

namespace OrganistsSchedule.WebApi.Controllers;

[Route("v1/ceps")]
public class CepController(ICepService service) 
    : ControllerBase<CepDto, Cep>(service)
{

}