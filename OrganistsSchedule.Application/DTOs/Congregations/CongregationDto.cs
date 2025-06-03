using System.ComponentModel.DataAnnotations;

namespace OrganistsSchedule.Application.DTOs;

public class CongregationDto
{
    public long Id { get; set; }
    public string? Name { get; set; }
    
    public string? RelatorioBrasCode { get; set; }
    
    public AddressDto? Address { get; set; }
    public ICollection<OrganistDto>? Organists { get; set; }
    
    public ICollection<DayOfWeek> DaysOfService { get; set; } = new List<DayOfWeek>();
    
    public bool HasYouthMeetings { get; set; }
}