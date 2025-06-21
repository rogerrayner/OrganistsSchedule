using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Bff.Interfaces;

public interface ICepBffService : ICrudBffServiceBase<
    Cep,
    CepDto,
    CepPagedAndSortedRequest,
    CepDto>
{
    Task<CepDto> GetCepByZipCodeAsync(string zipCode, 
        bool searchOnline = true, 
        CancellationToken cancellationToken = default
        );
    
    Task<IEnumerable<string>> GetDistrictsByCityIdAsync(
        long cityId,
        CancellationToken cancellationToken = default
        );
}


