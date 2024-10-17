using System.ComponentModel.DataAnnotations;

namespace OrganistsSchedule.Application.DTOs;

public class PhoneDto
{
    public long Id { get; set; }
    [Required(ErrorMessage = "Phone number is required")]
    public long Number { get; set; }
    public bool IsPrimary { get; set; }
    public OrganistDto? Organist { get; set; }
}