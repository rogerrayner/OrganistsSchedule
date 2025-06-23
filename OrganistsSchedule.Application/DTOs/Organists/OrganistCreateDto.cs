using System.ComponentModel.DataAnnotations;
using OrganistsSchedule.Domain.Enums;

namespace OrganistsSchedule.Application.DTOs;

public class OrganistCreateDto
{
    
    public string? Cpf { get; set; }
    [Required(ErrorMessage = "Full Name is required")]
    public required string FullName { get; set; }
    [Required(ErrorMessage = "Short Name is required")]
    public required string ShortName { get; set; }
    [Required(ErrorMessage = "Level is required")]
    public OrganistsLevelEnum Level { get; set; }
    [Required(ErrorMessage = "Cep is required")]
    public CepDto Cep { get; set; }
    
}