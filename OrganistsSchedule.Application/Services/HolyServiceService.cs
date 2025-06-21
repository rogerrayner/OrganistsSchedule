using System.Data;
using System.Text.Json;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Exceptions;
using OrganistsSchedule.Domain.Interfaces;
using OrganistsSchedule.Domain.Utils;

namespace OrganistsSchedule.Application.Services;

public class HolyServiceService(
    IHolyServiceRepository<HolyServicePagedAndSortedRequest> repository,
    IScheduleOrganistsService scheduleOrganistsService,
    IParameterScheduleRepository<ParameterSchedulePagedAndSortedRequest> parameterScheduleRepository,
    ICongregationRepository<CongregationPagedAndSortedRequest> congregationRepository,
    IUnitOfWork unitOfWork)
    : CrudServiceBase<HolyService, 
            HolyServicePagedAndSortedRequest>(repository, unitOfWork),
        IHolyServiceService
{
    public async Task<IEnumerable<HolyService>> ScheduleOrganistsForHolyServicesAsync(long congregationId,
        DateTime startDate,
        DateTime endDate,
        CancellationToken cancellationToken = default)
    {
        await using var transaction =
            await unitOfWork.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken);
        try
        {
            var congregation = await congregationRepository.GetByIdAsync(congregationId, cancellationToken);
            if (congregation == null)
                ErrorHandler.ThrowNotFoundException(Messages.NotFound, "Congregação");

            var parameterSchedule = await parameterScheduleRepository
                .HasDateRangeOverlapAsync(congregationId, startDate, endDate, cancellationToken);

            if (parameterSchedule)
                ErrorHandler.ThrowBusinessException(Messages.GenerationSchedule1015);

            var parameter = new ParameterSchedule
            {
                CongregationId = congregationId,
                StartDate = startDate,
                EndDate = endDate
            };

            parameter = await parameterScheduleRepository.CreateAsync(parameter, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            
            var holyServices = await scheduleOrganistsService.ScheduleOrganistsForHolyServices(parameter, cancellationToken);
            
            var existingHolyServices = await repository.GetHolyServicesByCongregationAsync(parameter.Congregation.Id, cancellationToken);
            await repository.BulkDeleteAsync(existingHolyServices, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            
            var createdHolyServices = await repository.BulkCreateAsync(holyServices, cancellationToken);
            await transaction.CommitAsync(cancellationToken);
            return createdHolyServices;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }
    }

    public async Task<IEnumerable<HolyService>> GetHolyServicesByCongregationIdAsync(long congregationId,
        CancellationToken cancellationToken = default)
    {
        var holyServices = await repository
            .GetHolyServicesByCongregationAsync(congregationId, cancellationToken);

        return holyServices;
    }
}