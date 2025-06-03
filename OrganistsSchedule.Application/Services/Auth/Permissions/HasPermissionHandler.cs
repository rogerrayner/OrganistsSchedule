using Microsoft.AspNetCore.Authorization;
using OrganistsSchedule.Application.Services;

public class HasPermissionHandler : AuthorizationHandler<HasPermissionRequirement>
{
    protected override Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        HasPermissionRequirement requirement)
    {
        // Busca todos os claims "permissions"
        var permissions = context.User.FindAll("permissions").Select(c => c.Value);

        // Valida se o usuário possui a permissão exigida
        if (permissions.Contains(requirement.Permission))
            context.Succeed(requirement);

        return Task.CompletedTask;
    }
}