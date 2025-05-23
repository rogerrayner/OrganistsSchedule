using System.ComponentModel.DataAnnotations;

namespace OrganistsSchedule.Application.DTOs;

public class CountryCreateUpdateRequestDto
{
    [Required(ErrorMessage = "Coutry Name is required")]
    public string? Name { get; set; }
}