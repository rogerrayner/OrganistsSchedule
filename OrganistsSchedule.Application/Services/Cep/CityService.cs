using AutoMapper;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Application.Services;

public class CityService(IMapper mapper, ICityRepository repository, IUnitOfWork unitOfWork) 
    : CrudServiceBase<City, CityDto, CityCreateUpdateRequestDto>(mapper, repository, unitOfWork), 
        ICityService
{
    public async Task<CityDto> GetByNameAsync(string name)
    {
        var entity = await repository.GetByNameAsync(name);
        return await Task
            .FromResult(mapper.Map<CityDto>(entity));
    }
}