using System.ComponentModel.DataAnnotations;

namespace OrganistsSchedule.Application.DTOs;

public class HolyServiceScheduleRequestDto
{
    [Required(ErrorMessage = "Start Date is required")]
    public DateTime StartDate { get; set; }
    [Required(ErrorMessage = "End Date is required")]
    public DateTime EndDate { get; set; }
}