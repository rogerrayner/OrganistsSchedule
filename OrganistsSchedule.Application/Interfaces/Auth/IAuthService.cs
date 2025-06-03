
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace OrganistsSchedule.Application.Interfaces;

public interface IAuthService
{
    Task<bool> IsAuthorized(ClaimsPrincipal user, IAuthorizationService authorizationService, string[] permissions,
        CancellationToken cancellationToken = default);
}