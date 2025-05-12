using System.ComponentModel.DataAnnotations;

namespace OrganistsSchedule.Application.DTOs;

public class CepDto
{

    public long Id { get; set; }
    [Required(ErrorMessage = "ZipCode is required")]
    public string? ZipCode { get; set; }
    [Required(ErrorMessage = "Street is required")]
    public string? Street { get; set; }
    [Required(ErrorMessage = "District is required")]
    public string? District { get; set; }
    //TODO avaliar o erro que está ocorrendo aqui
    public CityDto? City { get; set; } 
    
}