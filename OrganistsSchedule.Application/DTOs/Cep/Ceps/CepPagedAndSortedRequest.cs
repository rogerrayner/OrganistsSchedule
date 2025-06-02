using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Application.Services.Requests;

namespace OrganistsSchedule.Application.DTOs;

public class CepPagedAndSortedRequest: PagedAndSortedRequestDto
{
    public string? ZipCode { get; set; }
}