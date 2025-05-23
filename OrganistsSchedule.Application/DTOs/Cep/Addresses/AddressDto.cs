using System.ComponentModel.DataAnnotations;

namespace OrganistsSchedule.Application.DTOs;

public class AddressDto
{
    public long Id { get; set; }
    public CepDto? Cep { get; set; }
    public long StreetNumber { get; set; }
    public string? Complement { get; set; }
}