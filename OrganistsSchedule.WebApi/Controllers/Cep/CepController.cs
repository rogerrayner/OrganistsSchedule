using AutoMapper;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;

using Microsoft.AspNetCore.Mvc;

namespace OrganistsSchedule.WebApi.Controllers;

[Route("v1/ceps")]
public class CepController(ICepService service, IMapper mapper) 
    : ControllerBase<Cep, CepDto, CepCreateUpdateRequestDto, CepCreateUpdateRequestDto>(service, mapper)
{
    [HttpGet]
    [Route("viaCeps/{zipCode}")]
    public async Task<CepDto> GetCepByZipCodeAsync(string zipCode)
    {
        return await service.GetCepByZipCodeAsync(zipCode, false);
    }
    
    [HttpPost]
    [Route("viaCeps/{zipCode}")]
    public async Task<CepDto> GenerateCepByZipCode(string zipCode)
    {
        return await service.GetCepByZipCodeAsync(zipCode, true);
    }

    [NonAction]
    public override Task<CepDto> CreateAsync(CepCreateUpdateRequestDto dto, CancellationToken cancellationToken = default)
    {
        return base.CreateAsync(dto, cancellationToken);
    }

    [NonAction]
    public override Task<CepDto> UpdateAsync(CepCreateUpdateRequestDto dto, long id, CancellationToken cancellationToken = default)
    {
        return base.UpdateAsync(dto, id, cancellationToken);
    }
}