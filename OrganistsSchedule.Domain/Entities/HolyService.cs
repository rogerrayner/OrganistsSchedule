
namespace OrganistsSchedule.Domain.Entities;

public sealed class HolyService: AuditableEntityBase
{
    public required DateTime Date { get; set; }
    public required long CongregationId { get; set; }
    public Congregation? Congregation { get; set; }
    public long OrganistId { get; set; }
    public Organist? Organist { get; set; }
    public required bool IsYouthMeeting { get; set; } 
    
    public long ParameterScheduleId { get; set; }
    public ParameterSchedule? ParameterSchedule { get; set; }
}