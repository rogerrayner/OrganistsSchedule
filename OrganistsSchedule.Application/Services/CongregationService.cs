using AutoMapper;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Application.Services;

public class CongregationService(IMapper mapper, ICongregationRepository repository)
    : CrudServiceBase<CongregationDto, Congregation>(mapper, repository),
        ICongregationService
{
    
}