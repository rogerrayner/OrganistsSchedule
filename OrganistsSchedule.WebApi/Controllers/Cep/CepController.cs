using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Bff.Interfaces;

namespace OrganistsSchedule.WebApi.Controllers;

[Route("v1/ceps")]
public class CepController(ICepBffService service, IAuthService authService) 
    : ControllerBase<Cep, 
        CepDto,
        CepPagedAndSortedRequest,
        CepDto,
        CepDto>(service, authService)
{
    
    protected override string ReadPolicy => "read:cep";
    protected override string UpdatePolicy => "update:cep";
    protected override string CreatePolicy => "create:cep";
    protected override string DeletePolicy => "delete:cep";
    
    [HttpGet]
    [Route("viaCeps/{zipCode}")]
    public async Task<CepDto> GetCepByZipCodeAsync(string zipCode)
    {
        return await service.GetCepByZipCodeAsync(zipCode);
    }

    [NonAction]
    public override Task<ActionResult<CepDto>> UpdateAsync(CepDto dto, long id, CancellationToken cancellationToken = default)
    {
        return base.UpdateAsync(dto, id, cancellationToken);
    }
    
    [HttpGet]
    [Route("cities/{cityId}/districts")]
    public async Task<PagedResultDto<string>> GetDistrictsByCityIdAsync(long cityId, 
        CancellationToken cancellationToken = default)
    {
        var result = await service.GetDistrictsByCityIdAsync(cityId, cancellationToken);
        return new PagedResultDto<string>(result, result.Count());
    }
}