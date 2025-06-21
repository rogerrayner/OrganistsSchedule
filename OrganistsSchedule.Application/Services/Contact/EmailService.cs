using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Application.Services;

public class EmailService(
    IEmailRepository<EmailPagedAndSortedRequest> repository, 
    IUnitOfWork unitOfWork) 
    : CrudServiceBase<Email, 
            EmailPagedAndSortedRequest>(repository, unitOfWork), 
        IEmailService
{
    
}