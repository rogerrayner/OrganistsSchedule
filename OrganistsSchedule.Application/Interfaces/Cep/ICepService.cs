using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Application.Interfaces;

public interface ICepService: ICrudServiceBase<Cep, CepPagedAndSortedRequest>
{
    Task<Cep> GetCepByZipCodeAsync(string zipCode, bool searchOnline = true, CancellationToken cancellationToken = default);
    Task<Cep> GetCepByOnlineServiceAsync(string zipCode, CancellationToken cancellationToken = default);
    Task<List<string>> GetDistrictsByCityIdAsync(
        long cityId,
        CancellationToken cancellationToken = default);
}