using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Application.DTOs;

public class CepPagedAndSortedRequest: PagedAndSortedRequestDto, IPagedAndSortedRequest
{
    public string? ZipCode { get; set; }
    public string? Street {get; set;}
    
    public long? CityId { get; set; }
}