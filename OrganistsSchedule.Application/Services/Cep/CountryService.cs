using AutoMapper;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Application.Services;

public class CountryService(IMapper mapper, ICountryRepository repository, IUnitOfWork unitOfWork) 
    : CrudServiceBase<Country, 
            CountryResponseDto, 
            CountryPagedAndSortedRequest,
            CountryCreateUpdateRequestDto>(mapper, repository, unitOfWork), 
        ICountryService
{
    public async Task<CountryResponseDto> GetByNameAsync(string name)
    {
        var entity = await repository.GetByNameAsync(name);
        return await Task
            .FromResult(mapper.Map<CountryResponseDto>(entity));
    }
}