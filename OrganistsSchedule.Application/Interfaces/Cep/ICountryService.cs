using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Application.Interfaces;

public interface ICountryService: ICrudServiceBase<Country, CountryResponseDto, CountryPagedAndSortedRequest, CountryCreateUpdateRequestDto>
{
    Task<CountryResponseDto> GetByNameAsync(string name);
}