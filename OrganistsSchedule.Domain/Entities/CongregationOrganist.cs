using OrganistsSchedule.Domain.Entities;

public class CongregationOrganist
{
    public long CongregationId { get; set; }
    public Congregation Congregation { get; set; }
    public long OrganistId { get; set; }
    public Organist Organist { get; set; }

    public DayOfWeek[] OrganistServiceDaysOfWeek { get; set; } = [];
    
    public int Sequence { get; set; }
}