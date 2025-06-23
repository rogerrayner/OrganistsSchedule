using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Infra.Data.Responses;

internal class CongregationWithHolyServiceFlag : ICongregationWithHolyServiceFlag
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string RelatorioBrasCode { get; set; }
    public Address Address { get; set; }
    public bool HasYouthMeetings { get; set; }
    public bool HasGeneratedSchedule { get; set; }
    public DayOfWeek[] DaysOfService { get; set; }
}