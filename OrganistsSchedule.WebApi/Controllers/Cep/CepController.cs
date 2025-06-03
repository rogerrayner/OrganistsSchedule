using AutoMapper;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;

using Microsoft.AspNetCore.Mvc;
using OrganistsSchedule.Application;
using OrganistsSchedule.Application.Services;
using OrganistsSchedule.Application.Services.Requests;

namespace OrganistsSchedule.WebApi.Controllers;

[Route("v1/ceps")]
public class CepController(ICepService service, IMapper mapper, IAuthService authService) 
    : ControllerBase<Cep, 
        CepDto, 
        CepPagedAndSortedRequest,
        CepCreateUpdateRequestDto, 
        CepCreateUpdateRequestDto>(service, mapper, authService)
{
    
    protected override string ReadPolicy => "read:cep";
    protected override string UpdatePolicy => "update:cep";
    protected override string CreatePolicy => "create:cep";
    protected override string DeletePolicy => "delete:cep";
    
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
    public override Task<ActionResult<CepDto>> CreateAsync(CepCreateUpdateRequestDto dto, CancellationToken cancellationToken = default)
    {
        return base.CreateAsync(dto, cancellationToken);
    }

    [NonAction]
    public override Task<ActionResult<CepDto>> UpdateAsync(CepCreateUpdateRequestDto dto, long id, CancellationToken cancellationToken = default)
    {
        return base.UpdateAsync(dto, id, cancellationToken);
    }
}