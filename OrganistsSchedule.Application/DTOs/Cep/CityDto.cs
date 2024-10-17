using System.ComponentModel.DataAnnotations;

namespace OrganistsSchedule.Application.DTOs;

public class CityDto
{
    public long Id { get; set; }
    
    [Required(ErrorMessage = "City Name is required")]
    public string? Name { get; set; }
    
    [Required(ErrorMessage = "Country is required")]
    public CountryDto? Country { get; set; }
    public ICollection<CepDto>? Addresses { get; set; }
}