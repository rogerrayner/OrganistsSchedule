using AutoMapper;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Application.Services;

public class HolyServiceService(IMapper mapper, IHolyServiceRepository repository) 
        : CrudServiceBase<HolyServiceDto, HolyService>(mapper, repository),
        IHolyServiceService
{

}