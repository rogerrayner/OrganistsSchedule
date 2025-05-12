
namespace OrganistsSchedule.Domain.Entities;

public sealed class HolyService: EntityBase
{
    public required DateTime Date { get; set; }
    public long CongregationId { get; set; }
    public required Congregation Congregation { get; set; }
    public long OrganistId { get; set; }
    public Organist? Organist { get; set; }
    public required bool IsYouthMeeting { get; set; } 
}