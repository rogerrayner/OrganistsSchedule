using AutoMapper;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Application.Services;

public class EmailService(IMapper mapper, IEmailRepository repository, IUnitOfWork unitOfWork) 
    : CrudServiceBase<Email, 
            EmailDto, 
            EmailPagedAndSortedRequest,
            EmailCreateUpdateRequestDto>(mapper, repository, unitOfWork), 
        IEmailService
{
    
}