using System.ComponentModel.DataAnnotations;

namespace OrganistsSchedule.Application.DTOs;

public class CepCreateUpdateRequestDto
{
    [Required(ErrorMessage = "ZipCode is required")]
    public required string ZipCode { get; set; }
}