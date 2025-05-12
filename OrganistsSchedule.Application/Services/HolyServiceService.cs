using AutoMapper;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Application.Services;

public class HolyServiceService(IMapper mapper, 
        IHolyServiceRepository repository, 
        IScheduleOrganistsService _scheduleOrganistsService,
        IParameterScheduleService _parameterScheduleService,
        ICongregationService _congregationService)
        : CrudServiceBase<HolyServiceDto, HolyService>(mapper, repository),
        IHolyServiceService
{
        protected readonly IScheduleOrganistsService scheduleOrganistsService = _scheduleOrganistsService;
        protected readonly IParameterScheduleService parameterScheduleService = _parameterScheduleService;
        protected readonly ICongregationService congregationService = _congregationService;
        
        public async Task<PagedResultDto<HolyServiceDto>> ScheduleOrganistsForHolyServices(long congregationId, HolyServiceScheduleRequestDto dates)
        {

                var congregation = await congregationService.GetByIdAsync(congregationId);
                
                ParameterSchedule parameter = new ParameterSchedule()
                {
                        Congregation = null,
                        CongregationId = congregationId,
                        StartDate = dates.StartDate,
                        EndDate = dates.EndDate
                };
                
                var holyServices = scheduleOrganistsService.ScheduleOrganistsForHolyServices(parameter);
                repository.BulkDeleteAsync(
                        repository
                                .GetHolyServicesByCongregationAsync(parameter.Congregation.Id)
                                .Result);
                
                repository.BulkCreateAsync(holyServices);
                
                var totalCount = holyServices.Count;

                return new PagedResultDto<HolyServiceDto>(
                        mapper.Map<IEnumerable<HolyServiceDto>>(holyServices), 
                        totalCount);
        }
}