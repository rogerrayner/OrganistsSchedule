using System.ComponentModel.DataAnnotations;
using OrganistsSchedule.Domain.Enums;

namespace OrganistsSchedule.Application.DTOs;

public class OrganistCreateDto
{
    
    public string? Cpf { get; set; }
    [Required(ErrorMessage = "Full Name is required")]
    public required string FullName { get; set; }

    public required string ShortName { get; set; }
    
    public OrganistsLevelEnum Level { get; set; }
    
    public AddressCreateUpdateDto Address { get; set; }
    
    public string? PhoneNumber { get; set; }
    
    public string? Email { get; set; }
    
    [Required(ErrorMessage = "Days of Service is required")]
    public required DayOfWeek[] ServicesDaysOfWeek { get; set; }
}