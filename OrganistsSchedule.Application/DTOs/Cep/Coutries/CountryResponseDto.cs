using System.ComponentModel.DataAnnotations;

namespace OrganistsSchedule.Application.DTOs;

public class CountryResponseDto
{
    public long Id { get; set; }
    public string? Name { get; set; }
}