using System.ComponentModel.DataAnnotations;

namespace OrganistsSchedule.Application.DTOs;

public class CongregationDto
{
    public long Id { get; set; }
    [Required(ErrorMessage = "Name is required")]
    [MaxLength(200, ErrorMessage = "Name cannot be more than 200 characters")]
    public string? Name { get; set; }
    
    [Required(ErrorMessage = "Address is required")]
    public AddressDto? Address { get; set; }
    public ICollection<OrganistDto>? Organists { get; set; }
    
    [Required(ErrorMessage = "Days of Service is required")]
    public ICollection<DayOfWeek> DaysOfService { get; set; } = new List<DayOfWeek>();
    
    [Required(ErrorMessage = "Has Youth Meeting is required")]
    public bool HasYouthMeetings { get; set; }
}