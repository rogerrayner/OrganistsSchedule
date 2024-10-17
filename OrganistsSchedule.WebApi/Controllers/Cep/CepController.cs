using Microsoft.AspNetCore.Mvc;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.WebApi.Controllers;

public class CepController(ICepService service) 
    : ControllerBase<CepDto, Cep>(service)
{
    [HttpGet]
    [Route("/api/Cep/getByZipCode")]
    public async Task<IActionResult> GetCepByZipCodeAsync(string zipCode)
    {
        var dto = await service.GetCepByZipCodeAsync(zipCode);
        return dto == null ? NotFound() : Ok(dto);
    }
}