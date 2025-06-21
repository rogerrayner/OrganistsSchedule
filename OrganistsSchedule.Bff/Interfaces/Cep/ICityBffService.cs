using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Bff.Interfaces;

public interface ICityBffService: ICrudBffServiceBase<City, 
    CityDto, 
    CityPagedAndSortedRequest,
    CityCreateUpdateRequestDto>
{
    Task<CityDto> GetByNameAsync(string name);
}