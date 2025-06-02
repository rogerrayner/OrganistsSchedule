using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Application.Interfaces;

public interface ICityService: ICrudServiceBase<City, CityDto, CityPagedAndSortedRequest, CityCreateUpdateRequestDto>
{
    Task<CityDto> GetByNameAsync(string name);
}