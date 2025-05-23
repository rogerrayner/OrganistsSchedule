using System.ComponentModel.DataAnnotations;

namespace OrganistsSchedule.Application.DTOs;

public class CountryDto
{
    public long Id { get; set; }
    [Required(ErrorMessage = "Coutry Name is required")]
    public required string Name { get; set; }
    public ICollection<CityDto>? Cities { get; set; }
}