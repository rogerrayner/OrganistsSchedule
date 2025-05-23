using System.ComponentModel.DataAnnotations;

namespace OrganistsSchedule.Application.DTOs;

public class EmailCreateUpdateRequestDto
{
    [Required(ErrorMessage = "Email is required")]
    public string? EmailAddress { get; set; }
    public bool IsPrimary { get; set; }
    public long? OrganistId { get; set; }
}