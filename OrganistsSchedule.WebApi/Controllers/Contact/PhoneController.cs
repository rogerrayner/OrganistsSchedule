using AutoMapper;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;

using Microsoft.AspNetCore.Mvc;

namespace OrganistsSchedule.WebApi.Controllers;

[Route("v1/phones")]
public class PhoneController(IPhoneService serviceBase, IMapper mapper) 
    : ControllerBase<PhoneDto, Phone>(serviceBase, mapper)
{
    
}