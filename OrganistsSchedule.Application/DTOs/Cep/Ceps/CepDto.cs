namespace OrganistsSchedule.Application.DTOs;

public class CepDto
{
    public long Id { get; set; }
    public string? ZipCode { get; set; }
    public string? Street { get; set; }
    public string? District { get; set; }
    public long CityId { get; set; }
    public CityDto? City { get; set; }
}