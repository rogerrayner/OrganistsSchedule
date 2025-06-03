using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Application.Interfaces;

public interface ICepService: ICrudServiceBase<Cep, CepDto, CepPagedAndSortedRequest, CepCreateUpdateRequestDto>
{
    Task<CepDto> GetCepByZipCodeAsync(string cep, bool isPost, CancellationToken cancellationToken = default);
    Task<CepDto> GetCepByOnlineServiceAsync(string cep, bool isPost, CancellationToken cancellationToken = default);
}