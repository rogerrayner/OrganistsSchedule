
namespace OrganistsSchedule.Domain.Entities;

public sealed class ParameterSchedule: EntityBase
{
    public required Congregation Congregation { get; set; }
    public required DateTime StartDate { get; set; }
    public required DateTime EndDate { get; set; }
}