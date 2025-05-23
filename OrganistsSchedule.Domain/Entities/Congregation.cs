
namespace OrganistsSchedule.Domain.Entities;

public sealed class Congregation: AuditableEntityBase
{
    public required string Name { get; set; }

    public long? AddressId { get; set; }
    public Address? Address { get; set; }
    public ICollection<Organist>? Organists { get; set; }
    public DayOfWeek[] DaysOfService { get; set; }
    public required bool HasYouthMeetings { get; set; }
}