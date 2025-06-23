using AutoMapper;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Bff.Interfaces;
using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Bff.Services;

public class CountryBffService(IMapper mapper, 
    ICountryService service) 
    : CrudBffServiceBase<Country, 
            CountryResponseDto, 
            CountryPagedAndSortedRequest,
            CountryCreateUpdateRequestDto>(mapper, service), 
        ICountryBffService
{
    public async Task<CountryDto> GetByNameAsync(string name)
    {
        var entity = await service.GetByNameAsync(name);
        return mapper.Map<CountryDto>(entity);
    }
}