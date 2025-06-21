using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Domain.Interfaces;

public interface ICongregationWithHolyServiceFlag
{
    long Id { get; }
    string Name { get; }
    string RelatorioBrasCode { get; }
    Address Address { get; }
    bool HasYouthMeetings { get; }
    bool HasGeneratedSchedule { get; }
    DayOfWeek[] DaysOfService { get; set; }
}