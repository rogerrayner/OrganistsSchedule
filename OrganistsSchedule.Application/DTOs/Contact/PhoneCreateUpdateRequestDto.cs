using System.ComponentModel.DataAnnotations;

namespace OrganistsSchedule.Application.DTOs;

public class PhoneCreateUpdateRequestDto
{
    [Required(ErrorMessage = "Phone number is required")]
    public long Number { get; set; }
    public bool IsPrimary { get; set; }
    public long? OrganistId { get; set; }
}