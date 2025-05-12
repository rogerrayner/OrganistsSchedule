using AutoMapper;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Application.Services;

public class HolyServiceService(IMapper mapper, 
        IHolyServiceRepository repository, 
        IScheduleOrganistsService scheduleOrganistsService,
        IParameterScheduleService parameterScheduleService,
        ICongregationService congregationService)
        : CrudServiceBase<HolyServiceDto, HolyService>(mapper, repository),
        IHolyServiceService
{
        
        public async Task<PagedResultDto<HolyServiceDto>> ScheduleOrganistsForHolyServices(long congregationId, HolyServiceScheduleRequestDto dates)
        {

                var congregation = await congregationService.GetByIdAsync(congregationId);
                
                if (congregation == null) 
                    throw new ArgumentException("Congregation not found");
                
                var parameterSchedule = parameterScheduleService
                        .GetByRangeDateAndCongregationIdAsync(congregationId, dates.StartDate, dates.EndDate);

                if (parameterSchedule != null) 
                    throw new Exception("Parameter schedule already exists");
                
                ParameterSchedule parameter = new ParameterSchedule()
                {
                        CongregationId = congregationId,
                        StartDate = dates.StartDate,
                        EndDate = dates.EndDate
                };
                
                parameter = await parameterScheduleService.CreateAsync(mapper.Map<ParameterScheduleDto>(parameter));
                
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