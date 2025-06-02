using System.Data;
using AutoMapper;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Exceptions;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Application.Services;

public class HolyServiceService(
    IMapper mapper,
    IHolyServiceRepository repository,
    IScheduleOrganistsService scheduleOrganistsService,
    IParameterScheduleRepository parameterScheduleRepository,
    ICongregationRepository congregationRepository,
    IUnitOfWork unitOfWork)
    : CrudServiceBase<HolyService, 
            HolyServiceDto,
            HolyServicePagedAndSortedRequest>(mapper, repository, unitOfWork),
        IHolyServiceService
{
    public async Task<PagedResultDto<HolyServiceDto>> ScheduleOrganistsForHolyServicesAsync(long congregationId,
        HolyServiceScheduleRequestDto dates,
        CancellationToken cancellationToken = default)
    {
        await using var transaction =
            await unitOfWork.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken);
        try
        {
            var congregation = await congregationRepository.GetByIdAsync(congregationId, cancellationToken);
            if (congregation == null)
                throw new NotFoundException(Messages.Format(Messages.NotFound, "Congregação"));

            var parameterSchedule = await parameterScheduleRepository
                .GetByRangeDateAndCongregationIdAsync(congregationId, dates.StartDate, dates.EndDate, cancellationToken);

            if (parameterSchedule != null)
                throw new BusinessException(Messages.Format(Messages.AlreadyExists, "Parametros de Agendamento"));

            var parameter = new ParameterSchedule
            {
                CongregationId = congregationId,
                StartDate = dates.StartDate,
                EndDate = dates.EndDate
            };

            parameter = await parameterScheduleRepository.CreateAsync(parameter, cancellationToken);

            var holyServices = await scheduleOrganistsService.ScheduleOrganistsForHolyServices(parameter, cancellationToken);

            var existingHolyServices = await repository.GetHolyServicesByCongregationAsync(parameter.Congregation.Id, cancellationToken);
            await repository.BulkDeleteAsync(existingHolyServices, cancellationToken);

            var createdHolyServices = await repository.BulkCreateAsync(holyServices, cancellationToken);
            await transaction.CommitAsync(cancellationToken);
            
            var totalCount = createdHolyServices.ToList().Count;

            return new PagedResultDto<HolyServiceDto>(
                mapper.Map<IEnumerable<HolyServiceDto>>(createdHolyServices),
                totalCount);
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }
    }

    public async Task<List<HolyServiceDto>> GetHolyServicesByCongregationIdAsync(long congregationId,
        CancellationToken cancellationToken = default)
    {
        var holyServices = await repository
            .GetHolyServicesByCongregationAsync(congregationId, cancellationToken);

        return mapper.Map<List<HolyServiceDto>>(holyServices);
    }
}