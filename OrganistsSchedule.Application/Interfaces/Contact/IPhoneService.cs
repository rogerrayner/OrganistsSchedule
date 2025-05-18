using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Application.Interfaces;

public interface IPhoneService: ICrudServiceBase<Phone, PhoneDto, PhoneCreateUpdateRequestDto>
{

}