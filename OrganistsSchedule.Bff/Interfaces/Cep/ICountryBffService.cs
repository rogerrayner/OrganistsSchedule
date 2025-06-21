using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Bff.Interfaces;

public interface ICountryBffService: ICrudBffServiceBase<Country, 
    CountryResponseDto, 
    CountryPagedAndSortedRequest, 
    CountryCreateUpdateRequestDto>
{
    Task<CountryDto> GetByNameAsync(string name);
}