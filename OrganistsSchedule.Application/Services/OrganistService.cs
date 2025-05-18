using AutoMapper;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Application.Services;

public class OrganistService(IMapper mapper, IOrganistRepository repository, IUnitOfWork unitOfWork) 
    : CrudServiceBase<Organist, OrganistDto>(mapper, repository, unitOfWork),
        IOrganistService
{
    public List<Organist> GetByIds(List<long> organistIds, CancellationToken cancellationToken = default)
    { 
        var organists = repository.GetAllAsync(cancellationToken).Result
            .Where(x => organistIds.Contains(x.Id))
            .ToList();

        return organists;
    }

    public List<Organist> GetByCongregation(long congregationId, CancellationToken cancellationToken = default)
    { 
        return repository.GetByCongregation(congregationId);
    }
}