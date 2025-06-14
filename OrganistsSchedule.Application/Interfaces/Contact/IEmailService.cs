using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Application.Interfaces;

public interface IEmailService: ICrudServiceBase<Email, EmailDto, EmailPagedAndSortedRequest, EmailCreateUpdateRequestDto>
{

}