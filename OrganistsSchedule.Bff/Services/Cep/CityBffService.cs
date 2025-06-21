using AutoMapper;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Bff.Interfaces;
using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Bff.Services;

public class CityBffService(IMapper mapper, 
    ICityService service) 
    : CrudBffServiceBase<City, 
            CityDto,
            CityPagedAndSortedRequest,
            CityCreateUpdateRequestDto>(mapper, service), 
        ICityBffService
{
    public async Task<CityDto> GetByNameAsync(string name)
    {
        var entity = await service.GetByNameAsync(name);
        return mapper.Map<CityDto>(entity);
    }
}