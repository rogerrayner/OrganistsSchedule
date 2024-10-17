using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Application.Interfaces;

public interface ICepService: ICrudServiceBase<CepDto, Cep>
{
    Task<CepDto> GetCepByZipCodeAsync(string cep);
    Task<CepDto> GetCepByOnlineServiceAsync(string cep);
}