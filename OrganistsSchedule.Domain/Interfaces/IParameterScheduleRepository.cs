using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Domain.Interfaces;

public interface IParameterScheduleRepository: IRepositoryBase<ParameterSchedule>
{
    ParameterSchedule GetByRangeDateAndCongregationIdAsync(long congregationId, DateTime startDate, DateTime endDate);
}