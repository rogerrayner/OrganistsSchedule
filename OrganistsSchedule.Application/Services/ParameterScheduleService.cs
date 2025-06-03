using AutoMapper;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Application.Services;

public class ParameterScheduleService(IMapper mapper, IParameterScheduleRepository repository, IUnitOfWork unitOfWork) 
    : CrudServiceBase<ParameterSchedule, 
            ParameterScheduleDto, 
            ParameterSchedulePagedAndSortedRequest,
            ParameterScheduleCreateUpdateDto>(mapper, repository, unitOfWork),
        IParameterScheduleService
{
    public async Task<ParameterSchedule> GetByRangeDateAndCongregationIdAsync(long congregationId, 
        DateTime startDate, 
        DateTime endDate,
        CancellationToken cancellationToken = default)
    {
        return await repository.GetByRangeDateAndCongregationIdAsync(congregationId, 
            startDate, 
            endDate,
            cancellationToken);
    }
}