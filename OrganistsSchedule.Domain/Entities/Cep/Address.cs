namespace OrganistsSchedule.Domain.Entities;

public sealed class Address: EntityBase
{
    public long CepId { get; set; }
    public Cep Cep{ get; set; }
    public required long StreetNumber { get; set; }
    public string? Complement { get; set; }
    public long? OrganistId { get; set; } 
    public Organist? Organist { get; set; }
    public long? CongregationId { get; set; }
    public Congregation? Congregation { get; set; }
}