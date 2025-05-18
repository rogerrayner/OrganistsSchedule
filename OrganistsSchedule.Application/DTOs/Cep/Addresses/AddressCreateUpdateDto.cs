using System.ComponentModel.DataAnnotations;

namespace OrganistsSchedule.Application.DTOs;

public class AddressCreateUpdateDto
{
    [Required(ErrorMessage = "Cep is required")]
    public string? ZipCode { get; set; }
    [Required(ErrorMessage = "Street Number is required")]
    public long StreetNumber { get; set; }
    public string? Complement { get; set; }
}