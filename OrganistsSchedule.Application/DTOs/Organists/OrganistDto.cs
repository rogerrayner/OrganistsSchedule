using System.ComponentModel.DataAnnotations;
using OrganistsSchedule.Domain.Enums;

namespace OrganistsSchedule.Application.DTOs;

public class OrganistDto
{
    public long Id { get; set; }
    public string? FullName { get; set; } 
    public string? ShortName { get; set; }
    public OrganistsLevelEnum Level { get; set; }
    public long IndividualAddressId { get; set; }
    public AddressDto? Address { get; set; }
    public ICollection<EmailDto>? Emails { get; set; }
    public PhoneDto? PhoneNumber { get; set; }
    public bool hasCongregation { get; set; }
}