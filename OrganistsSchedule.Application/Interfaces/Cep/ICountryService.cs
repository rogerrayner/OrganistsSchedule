using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Application.Interfaces;

public interface ICountryService: ICrudServiceBase<Country, CountryPagedAndSortedRequest>
{
    Task<Country?> GetByNameAsync(string name);
}