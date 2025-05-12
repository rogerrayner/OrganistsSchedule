using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Application.Interfaces;

public interface IParameterScheduleService: ICrudServiceBase<ParameterScheduleDto, ParameterSchedule>
{
    ParameterSchedule GetByRangeDateAndCongregationIdAsync(long congregationId, DateTime startDate, DateTime endDate);
}