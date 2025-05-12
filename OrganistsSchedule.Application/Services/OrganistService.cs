using AutoMapper;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Application.Services;

public class OrganistService(IMapper mapper, IOrganistRepository repository) 
    : CrudServiceBase<OrganistDto, Organist>(mapper, repository),
        IOrganistService
{
    public List<Organist> GetByIdsAsync(List<long> organistIds)
    { 
        var organists = repository.GetAllAsync().Result
            .Where(x => organistIds.Contains(x.Id))
            .ToList();

        return organists;
    }
}