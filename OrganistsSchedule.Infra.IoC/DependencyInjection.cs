using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrganistsSchedule.Application.Services;
using OrganistsSchedule.Bff.Mappings;
using OrganistsSchedule.Domain;
using OrganistsSchedule.Infra.Data;
using OrganistsSchedule.Infra.Data.Interceptors;
using Scrutor;
using ViaCep;

namespace OrganistsSchedule.Infra.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddSingleton<UpdateAuditedEntitiesInterceptor>();
        services.AddDbContext<ApplicationDbContext>(
            (sp, optionsBuilder) =>
        {
            var auditableInterceptor = sp.GetService<UpdateAuditedEntitiesInterceptor>()!;
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
                .AddInterceptors(auditableInterceptor);
        });
        
        services
            .Scan(
                selector => selector
                    .FromAssemblies(
                        OrganistsSchedule.Infra.Data.AssemblyReference.Assembly)
                    .AddClasses(false)
                    .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());
        
        return services;
    }
    
    public static IServiceCollection AddAuthorization(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthorization(options =>
        {
            foreach (var permission in Permissions.Policies)
            {
                options.AddPolicy(permission, policy =>
                    policy.Requirements.Add(new HasPermissionRequirement(permission)));
            }
        });

        services.AddSingleton<IAuthorizationHandler, HasPermissionHandler>();
        return services;
    }

    public static IServiceCollection AddApplication(this IServiceCollection services, 
        IConfiguration configuration)
    {
        services
            .Scan(
                selector => selector
                    .FromAssemblies(
                        OrganistsSchedule.Application.AssemblyReference.Assembly)
                    .AddClasses(classes => classes.Where(type => 
                        !type.IsDefined(typeof(DoNotRegisterAttribute), false)))
                    .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                    .AsImplementedInterfaces()
                    .WithScopedLifetime())
            ;
        
        services.AddHttpClient<IViaCepClient, ViaCepClient>(client => { client.BaseAddress = new Uri("https://viacep.com.br/"); });
        
        return services;
    }
    
    public static IServiceCollection AddBackendForFrontend(this IServiceCollection services, 
        IConfiguration configuration)
    {
        services
            .Scan(
                selector => selector
                    .FromAssemblies(
                        OrganistsSchedule.Bff.AssemblyReference.Assembly)
                    .AddClasses(classes => classes.Where(type => 
                        !type.IsDefined(typeof(DoNotRegisterAttribute), false)))
                    .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                    .AsImplementedInterfaces()
                    .WithScopedLifetime())
            ;

        services.AddAutoMapper(typeof(DomainToDtoMappingProfile));
        return services;
    }
    
    
}