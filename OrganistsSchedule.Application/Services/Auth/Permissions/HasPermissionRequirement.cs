using Microsoft.AspNetCore.Authorization;
using OrganistsSchedule.Domain;

namespace OrganistsSchedule.Application.Services;

[DoNotRegister]
public class HasPermissionRequirement(string permission): IAuthorizationRequirement
{
    public string Permission { get; } = permission;
}