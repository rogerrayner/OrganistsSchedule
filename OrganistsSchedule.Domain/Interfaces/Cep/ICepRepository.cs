using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Domain.Interfaces;

public interface ICepRepository: IRepositoryBase<Cep>
{
    Task<Cep?> GetCepByZipCodeAsync(string cep);
}