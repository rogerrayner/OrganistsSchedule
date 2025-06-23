

using AutoMapper;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Application.Specifications;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Bff.Interfaces;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Bff.Services;

public class CepBffService(IMapper mapper,
    ICepService service)
    : CrudBffServiceBase<Cep, 
            CepDto, 
            CepPagedAndSortedRequest,
            CepDto,
            CepDto>(mapper, service), 
        ICepBffService
{
    public override Task<PagedResultDto<CepDto>> GetAllAsync(CepPagedAndSortedRequest request, 
        CancellationToken cancellationToken = default,
        ISpecification<Cep>? specification = null)
    { 
        specification = new CepSpecification(request);
        return base.GetAllAsync(request, cancellationToken, specification);
    }

    public async Task<CepDto> GetCepByZipCodeAsync(string zipCode,
        bool searchOnline = true,
        CancellationToken cancellationToken = default)
    {
        var entity = await service.GetCepByZipCodeAsync(zipCode, searchOnline, cancellationToken);
        return mapper.Map<CepDto>(entity);
    }

    public async Task<IEnumerable<string>> GetDistrictsByCityIdAsync(
        long cityId,
        CancellationToken cancellationToken = default)
    {
        return await service.GetDistrictsByCityIdAsync(
            cityId,
            cancellationToken);
    }
}