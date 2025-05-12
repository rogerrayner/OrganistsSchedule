using OrganistsSchedule.Domain.Enums;

namespace OrganistsSchedule.Domain.Entities;

public sealed class Organist: EntityBase
{
    public required int Sequence { get; set; }
    public string? Cpf { get; set; }
    public required string FullName { get; set; }
    public required string ShortName { get; set; }
    public OrganistsLevelEnum Level { get; set; }
    
    public long? AddressId { get; set; }
    public Address? Address { get; set; }
    
    public long? CongregationId { get; set; }
    public Congregation? Congregation { get; set; }
    public ICollection<Email>? Emails { get; set; }
    
    public long? PhoneId { get; set; }
    public Phone? PhoneNumber { get; set; }
    public required DayOfWeek[] ServicesDaysOfWeek { get; set; }
}