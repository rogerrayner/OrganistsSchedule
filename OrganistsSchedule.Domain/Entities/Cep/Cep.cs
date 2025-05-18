namespace OrganistsSchedule.Domain.Entities;

public sealed class Cep: AuditableEntityBase
{
    public required string ZipCode { get; set; }
    public required string Street { get; set; }
    public required string District { get; set; }
    public long CityId { get; set; }
    public City? City { get; set; }
    
}