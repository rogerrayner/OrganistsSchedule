
namespace OrganistsSchedule.Domain.Entities;

public sealed class ParameterSchedule: EntityBase
{
    public Congregation Congregation { get; set; }
    public required long CongregationId { get; set; }
    public required DateTime StartDate { get; set; }
    public required DateTime EndDate { get; set; }
}