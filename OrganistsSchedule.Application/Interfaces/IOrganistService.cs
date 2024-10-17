using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Application.Interfaces;

public interface IOrganistService: ICrudServiceBase<OrganistDto, Organist>
{
    
}