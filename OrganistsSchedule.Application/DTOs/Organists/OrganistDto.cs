using System.ComponentModel.DataAnnotations;
using OrganistsSchedule.Domain.Enums;

namespace OrganistsSchedule.Application.DTOs;

public class OrganistDto
{
    public long Id { get; set; }
    [Required(ErrorMessage = "Sequence is required")]
    public int Sequence { get; set; }
    
    public string? Cpf { get; set; }
    [Required(ErrorMessage = "Full Name is required")]
    public string? FullName { get; set; }
    
    [Required(ErrorMessage = "Short Name is required")]
    public string? ShortName { get; set; }
    
    public OrganistsLevelEnum Level { get; set; }
    
    public long IndividualAddressId { get; set; }
    public AddressDto? Address { get; set; }
    public ICollection<EmailDto>? Emails { get; set; }
    public ICollection<CongregationDto>? Congregations { get; set; }
    public PhoneDto? PhoneNumber { get; set; }
    
    [Required(ErrorMessage = "Days of Service is required")]
    public ICollection<DayOfWeek> ServicesDaysOfWeek { get; set; } = [];
}