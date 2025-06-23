using OrganistsSchedule.Domain.Enums;

namespace OrganistsSchedule.Application.DTOs;

public class CongregationOrganistsDto
{
    public long OrganistId { get; set; }
    public OrganistDto Organist { get; set; }
    public long CongregationId { get; set; }
    public OrganistsLevelEnum Level { get; set; }
    public int Sequence { get; set; }
    public DayOfWeek[] OrganistServiceDaysOfWeek { get; set; }
}