using System.ComponentModel.DataAnnotations;

namespace OrganistsSchedule.Application.DTOs;

public class CongregationCreateRequestDto
{
    [Required(ErrorMessage = "Name is required")]
    [MaxLength(200, ErrorMessage = "Name cannot be more than 200 characters")]
    public string Name { get; set; }
    
    public long? AddressId { get; set; }
    
    [Required(ErrorMessage = "Days of Service is required")]
    public ICollection<DayOfWeek> DaysOfService { get; set; } = new List<DayOfWeek>();
    
    [Required(ErrorMessage = "Has Youth Meeting is required")]
    public bool HasYouthMeetings { get; set; }
}