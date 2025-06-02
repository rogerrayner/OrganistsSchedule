using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using OrganistsSchedule.Application.Interfaces;

namespace OrganistsSchedule.Application.Services;

public class AuthService: IAuthService
{
    public async Task<bool> IsAuthorized(ClaimsPrincipal user, IAuthorizationService authorizationService, string[] permissions,
        CancellationToken cancellationToken = default)
    {
        bool isAuthorized = false;
        
        if (!permissions.Contains("admin"))
        {
            permissions = permissions.Append("admin").ToArray();
        }
        
        foreach (var permission in permissions)
        {
            var authorizationResult = await authorizationService.AuthorizeAsync(user,null,permission);
            if (authorizationResult.Succeeded)
            {
                isAuthorized = true;
                break;
            }
        }
        
        return isAuthorized;
    }
}