using AutoMapper;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;
using System.Linq;

namespace OrganistsSchedule.Application.Services;

public class CongregationService(IMapper mapper, ICongregationRepository repository, IOrganistService organistService)
    : CrudServiceBase<CongregationDto, Congregation>(mapper, repository),
        ICongregationService
{

    protected IOrganistService _organistService = organistService;
    
    public async Task<CongregationDto> SetOrganistsAsync(long congregationId, List<long> organistIds)
    {
        var congregation = repository.GetByIdAsync(congregationId).Result;
        if (congregation == null)
            throw new Exception("Congregation not found");

        var organists = _organistService.GetByIdsAsync(organistIds);

        foreach (var organist in organists)
        {
            organist.CongregationId = congregation.Id;
            organist.Congregation = congregation;
        }

        congregation.Organists = organists;
        repository.UpdateAsync(congregation);
        return await Task.FromResult(mapper.Map<CongregationDto>(congregation));
    }
}