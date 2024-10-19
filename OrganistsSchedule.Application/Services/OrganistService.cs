using AutoMapper;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Application.Services;

public class OrganistService(IMapper mapper, IOrganistRepository repository) 
    : CrudServiceBase<OrganistDto, Organist>(mapper, repository),
        IOrganistService
{

}