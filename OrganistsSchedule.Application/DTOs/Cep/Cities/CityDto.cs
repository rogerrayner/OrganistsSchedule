using System.ComponentModel.DataAnnotations;

namespace OrganistsSchedule.Application.DTOs;

public class CityDto
{
    public long Id { get; set; }
    
    public string? Name { get; set; }
    
    public CountryDto? Country { get; set; }

}