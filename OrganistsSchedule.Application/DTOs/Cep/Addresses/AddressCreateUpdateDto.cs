using System.ComponentModel.DataAnnotations;

namespace OrganistsSchedule.Application.DTOs;

public class AddressCreateUpdateDto
{
    public long Id { get; set; }
    
    [Required(ErrorMessage = "Cep is required")]
    public CepDto Cep { get; set; }
    
    [Required(ErrorMessage = "Street Number is required")]
    public long StreetNumber { get; set; }
    public string? Complement { get; set; }
}