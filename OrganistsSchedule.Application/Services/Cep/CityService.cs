using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Application.Services;

public class CityService(
    ICityRepository<CityPagedAndSortedRequest> repository, 
    IUnitOfWork unitOfWork) 
    : CrudServiceBase<City, CityPagedAndSortedRequest>(repository, 
            unitOfWork), 
        ICityService
{
    public async Task<City?> GetByNameAsync(string name)
    {
        return await repository.GetByNameAsync(name);
    }
}