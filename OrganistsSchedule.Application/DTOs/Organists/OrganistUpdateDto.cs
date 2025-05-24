using System.ComponentModel.DataAnnotations;
using OrganistsSchedule.Domain.Enums;

namespace OrganistsSchedule.Application.DTOs;

public class OrganistUpdateDto
{
    public string? FullName { get; set; }

    public string? ShortName { get; set; }
    
    public OrganistsLevelEnum? Level { get; set; }
    
    public AddressCreateUpdateDto? Address { get; set; }
    
    public DayOfWeek[]? ServicesDaysOfWeek { get; set; }
}