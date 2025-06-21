namespace OrganistsSchedule.Domain.Entities;

public sealed class Congregation : AuditableEntityBase
{
    public required string Name { get; set; }
    public required string RelatorioBrasCode { get; set; }
    public long? AddressId { get; set; }
    public Address? Address { get; set; }
    public DayOfWeek[] DaysOfService { get; set; }
    public required bool HasYouthMeetings { get; set; }
    public ICollection<CongregationOrganist> CongregationOrganists { get; set; } = new List<CongregationOrganist>();
}