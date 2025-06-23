
namespace OrganistsSchedule.Domain.Entities;

public sealed class ParameterSchedule: AuditableEntityBase
{
    public Congregation Congregation { get; set; }
    public required long CongregationId { get; set; }
    public required DateTime StartDate { get; set; }
    public required DateTime EndDate { get; set; }
    
    public ICollection<HolyService> HolyServices { get; set; } = new List<HolyService>();

}