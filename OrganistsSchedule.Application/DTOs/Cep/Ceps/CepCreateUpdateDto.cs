namespace OrganistsSchedule.Application.DTOs;

public class CepCreateUpdateDto
{
    public long Id { get; set; }
    public string? ZipCode { get; set; }
    public string? Street { get; set; }
    public string? District { get; set; }
    public string? State { get; set; }
    public string? City { get; set; }
}