using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Application.Mappings;
using OrganistsSchedule.Application.Services;
using OrganistsSchedule.Domain.Identity;
using OrganistsSchedule.Domain.Interfaces;
using OrganistsSchedule.Infra.Data;
using OrganistsSchedule.Infra.Data.Identity;
using OrganistsSchedule.Infra.Data.Interceptors;
using OrganistsSchedule.Infra.Data.Repositories;
using OrganistsSchedule.Infrastructure.Seeds.Identity;
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

    public static IServiceCollection AddIdentityAuthentication(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddIdentityCore<UserIdentity>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddApiEndpoints();
        
        services.AddScoped<ISeedUserRoleInitial, UserRoleSeed>();

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
                    .AddClasses(false)
                    .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());
        
        services.AddHttpClient<IViaCepClient, ViaCepClient>(client => { client.BaseAddress = new Uri("https://viacep.com.br/"); });
        services.AddAutoMapper(typeof(DomainToDtoMappingProfile));
        return services;
    }
}