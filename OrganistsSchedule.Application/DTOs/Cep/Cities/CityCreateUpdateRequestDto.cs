using System.ComponentModel.DataAnnotations;

namespace OrganistsSchedule.Application.DTOs;

public class CityCreateUpdateRequestDto
{
    [Required(ErrorMessage = "City Name is required")]
    public required string Name { get; set; }
    
    public long? CountryId { get; set; }
}