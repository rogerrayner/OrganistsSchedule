using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Application.Interfaces;

public interface ICityService: ICrudServiceBase<City, CityPagedAndSortedRequest>
{
    Task<City?> GetByNameAsync(string name);
}