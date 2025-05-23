namespace OrganistsSchedule.Domain.Entities;

public sealed class City: AuditableEntityBase
{
    public required string Name { get; set; }
    
    public required long CountryId { get; set; }
    public Country? Country { get; set; }
}