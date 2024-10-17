using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Application.Mappings;
using OrganistsSchedule.Application.Services;
using OrganistsSchedule.Domain.Interfaces;
using OrganistsSchedule.Infra.Data;
using OrganistsSchedule.Infra.Data.Repositories;

namespace OrganistsSchedule.Infra.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options => 
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
        );
        
        services.AddScoped<ICepRepository, CepRepository>();
        services.AddScoped<ICityRepository, CityRepository>();
        services.AddScoped<ICountryRepository, CountryRepository>();
        services.AddScoped<IEmailRepository, EmailRepository>();
        services.AddScoped<ICongregationRepository, CongregationRepository>();
        services.AddScoped<IHolyServiceRepository, HolyServiceRepository>();
        services.AddScoped<IAddressRepository, AddressRepository>();
        services.AddScoped<IOrganistRepository, OrganistRepository>();
        services.AddScoped<IParameterScheduleRepository, ParameterScheduleRepository>();
        services.AddScoped<IPhoneRepository, PhoneRepository>();
        
        return services;
    }

    public static IServiceCollection AddApplication(this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.AddScoped<IOrganistService, OrganistService>();  
        services.AddScoped<ICongregationService, CongregationService>();
        services.AddScoped<IHolyServiceService, HolyServiceService>();
        services.AddScoped<ICepService, CepService>();
        services.AddScoped<IAddressService, AddressService>();
        services.AddScoped<ICountryService, CountryService>();
        services.AddScoped<ICityService, CityService>();
        services.AddScoped<IParameterScheduleService, ParameterScheduleService>();
        services.AddScoped<IPhoneService, PhoneService>();
        services.AddScoped<IEmailService, EmailService>();
        services.AddAutoMapper(typeof(DomainToDtoMappingProfile));
        return services;
    }
}