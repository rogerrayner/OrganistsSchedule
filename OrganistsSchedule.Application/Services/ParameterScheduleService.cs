using AutoMapper;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Application.Services;

public class ParameterScheduleService(IMapper mapper, IParameterScheduleRepository repository) 
    : CrudServiceBase<ParameterScheduleDto, ParameterSchedule>(mapper, repository),
        IParameterScheduleService
{
    public ParameterSchedule GetByRangeDateAndCongregationIdAsync(long congregationId, DateTime startDate, DateTime endDate)
    {
        return repository.GetByRangeDateAndCongregationIdAsync(congregationId, startDate, endDate);
    }
}