using AutoMapper;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;
using System.Linq;
using OrganistsSchedule.Domain.Exceptions;

namespace OrganistsSchedule.Application.Services;

public class CongregationService(IMapper mapper, ICongregationRepository repository, IOrganistService organistService, IUnitOfWork unitOfWork)
    : CrudServiceBase<Congregation, CongregationDto, CongregationCreateRequestDto, CongregationUpdateRequestDto>(mapper, repository, unitOfWork),
        ICongregationService
{
    public async Task<CongregationDto> SetOrganistsAsync(long congregationId, List<long> organistIds, CancellationToken cancellationToken = default)
    {
        var congregation = repository.GetByIdAsync(congregationId, cancellationToken).Result;
        if (congregation == null)
            throw new NotFoundException(Messages.Format(Messages.NotFound, "Congregação"));

        var organists = organistService.GetByIds(organistIds);

        foreach (var organist in organists)
        {
            organist.CongregationId = congregation.Id;
            organist.Congregation = congregation;
        }

        congregation.Organists = organists;
        repository.UpdateAsync(congregation, cancellationToken);
        return await Task.FromResult(mapper.Map<CongregationDto>(congregation));
    }
}