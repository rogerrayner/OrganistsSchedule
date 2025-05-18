using System.Data;
using AutoMapper;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Application.Services;

public class HolyServiceService(IMapper mapper, 
        IHolyServiceRepository repository,
        IScheduleOrganistsService scheduleOrganistsService,
        IParameterScheduleRepository parameterScheduleRepository,
        ICongregationRepository congregationRepository,
        IUnitOfWork unitOfWork)
        : CrudServiceBase<HolyService, HolyServiceDto>(mapper, repository, unitOfWork),
        IHolyServiceService
{
        public async Task<PagedResultDto<HolyServiceDto>> ScheduleOrganistsForHolyServices(long congregationId, 
                HolyServiceScheduleRequestDto dates,
                CancellationToken cancellationToken = default)
        {
                //TODO - implementar transactions
                using var transaction = unitOfWork.BeginTransaction(IsolationLevel.ReadCommitted);
                
                try
                {
                        var congregation = await congregationRepository.GetByIdAsync(congregationId, cancellationToken);

                        if (congregation == null)
                                throw new ArgumentException("Congregation not found");

                        var parameterSchedule = parameterScheduleRepository
                                .GetByRangeDateAndCongregationIdAsync(congregationId, dates.StartDate, dates.EndDate);

                        if (parameterSchedule != null)
                                throw new Exception("Parameter schedule already exists");

                        ParameterSchedule parameter = new ParameterSchedule()
                        {
                                CongregationId = congregationId,
                                StartDate = dates.StartDate,
                                EndDate = dates.EndDate
                        };

                        parameter = await parameterScheduleRepository.CreateAsync(parameter, cancellationToken);

                        var holyServices = scheduleOrganistsService.ScheduleOrganistsForHolyServices(parameter);
                        repository.BulkDeleteAsync(
                                repository
                                        .GetHolyServicesByCongregationAsync(parameter.Congregation.Id)
                                        .Result,
                                cancellationToken);

                        repository.BulkCreateAsync(holyServices, cancellationToken);

                        var totalCount = holyServices.Count;

                        return new PagedResultDto<HolyServiceDto>(
                                mapper.Map<IEnumerable<HolyServiceDto>>(holyServices),
                                totalCount);
                }
                catch (Exception e)
                {
                        transaction.Rollback();
                }

                return null;
        }

        public List<HolyServiceDto> GetHolyServicesByCongregationId(long congregationId,
                CancellationToken cancellationToken = default)
        {
                var holyServices = repository
                        .GetHolyServicesByCongregationAsync(congregationId)
                        .Result;

                return mapper.Map<List<HolyServiceDto>>(holyServices);
        }
}