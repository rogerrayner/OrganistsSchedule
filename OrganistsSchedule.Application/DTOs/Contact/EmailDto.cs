using System.ComponentModel.DataAnnotations;

namespace OrganistsSchedule.Application.DTOs;

public class EmailDto
{
    public long Id { get; set; }
    [Required(ErrorMessage = "Email is required")]
    public string? EmailAddress { get; set; }
    
    public bool IsPrimary { get; set; }
    public long? OrganistId { get; set; }
}