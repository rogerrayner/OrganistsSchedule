using System.ComponentModel.DataAnnotations;

namespace OrganistsSchedule.Application.DTOs;

public class ParameterScheduleDto
{
    public long Id { get; set; }
    [Required(ErrorMessage = "Congregation is required")]
    public CongregationDto? Congregation { get; set; }
    [Required(ErrorMessage = "Start Date is required")]
    public DateTime StartDate { get; set; }
    [Required(ErrorMessage = "End Date is required")]
    public DateTime EndDate { get; set; }
}