using System.ComponentModel.DataAnnotations;

namespace OrganistsSchedule.Application.DTOs;

public class CongregationCreateRequestDto
{
    [Required(ErrorMessage = "Código Relatório Bras is required")]
    [MaxLength(10, ErrorMessage = "Código Relatório Bras cannot be more than 10 characters")]
    public string? RelatorioBrasCode { get; set; }
    
    [Required(ErrorMessage = "Name is required")]
    [MaxLength(200, ErrorMessage = "Name cannot be more than 200 characters")]
    public string Name { get; set; }
    public AddressCreateUpdateDto Address { get; set; }
    
    [Required(ErrorMessage = "Days of Service is required")]
    public DayOfWeek[] DaysOfService { get; set; } = [];
    
    [Required(ErrorMessage = "Has Youth Meeting is required")]
    public bool HasYouthMeetings { get; set; }
}