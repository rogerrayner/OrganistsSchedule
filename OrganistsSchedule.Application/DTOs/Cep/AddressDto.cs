using System.ComponentModel.DataAnnotations;

namespace OrganistsSchedule.Application.DTOs;

public class AddressDto
{
    public long Id { get; set; }
    [Required(ErrorMessage = "Cep is required")]
    public CepDto? Cep { get; set; }
    [Required(ErrorMessage = "Street Number is required")]
    public long StreetNumber { get; set; }
    public string? Complement { get; set; }
    public long? OrganistId { get; set; } 
    public OrganistDto? Organist { get; set; }
    public CongregationDto? Congregation { get; set; }
}