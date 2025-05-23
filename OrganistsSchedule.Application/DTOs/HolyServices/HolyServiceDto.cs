using System.ComponentModel.DataAnnotations;

namespace OrganistsSchedule.Application.DTOs;

public class HolyServiceDto
{
    public long Id { get; set; }
    
    [Required(ErrorMessage = "Date is required")]
    public DateTime Date { get; set; }
    
    [Required(ErrorMessage = "Congregation is required")]
    public CongregationDto? Congregation { get; set; }
    
    public OrganistDto? Organist { get; set; }
    
    [Required(ErrorMessage = "IsYouthMeeting is required")]
    public required bool IsYouthMeeting { get; set; } 
}