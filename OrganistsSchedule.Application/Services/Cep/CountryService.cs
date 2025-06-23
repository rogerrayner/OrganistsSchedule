using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Application.Services;

public class CountryService(
    ICountryRepository<CountryPagedAndSortedRequest> repository, 
    IUnitOfWork unitOfWork) 
    : CrudServiceBase<Country, 
            CountryPagedAndSortedRequest>(repository, unitOfWork), 
        ICountryService
{
    public async Task<Country?> GetByNameAsync(string name)
    {
        return await repository.GetByNameAsync(name);
    }
}