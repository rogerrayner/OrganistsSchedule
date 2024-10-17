using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.WebApi.Controllers.Contact;

public class PhoneController(IPhoneService serviceBase) 
    : ControllerBase<PhoneDto, Phone>(serviceBase)
{
    
}