using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Application.Interfaces;

public interface ICityService: ICrudServiceBase<City, CityDto, CityCreateUpdateRequestDto>
{
    Task<CityDto> GetByNameAsync(string name);
}