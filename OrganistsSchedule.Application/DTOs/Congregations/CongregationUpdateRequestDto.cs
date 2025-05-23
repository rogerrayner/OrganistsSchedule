using System.ComponentModel.DataAnnotations;

namespace OrganistsSchedule.Application.DTOs;

public class CongregationUpdateRequestDto
{
    public string? Name { get; set; }
    
    public long? AddressId { get; set; }
    
    public ICollection<DayOfWeek>? DaysOfService { get; set; } = new List<DayOfWeek>();
    
    public bool? HasYouthMeetings { get; set; }
}