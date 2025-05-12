using Microsoft.AspNetCore.Identity;
using OrganistsSchedule.Domain.Identity;
using OrganistsSchedule.Infra.Data.Identity;
using OrganistsSchedule.Infra.IoC;

namespace OrganistsSchedule.WebApi;

public class Startup
{
    public IConfiguration Configuration { get; }
    
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddAuthentication(
            options =>
            {
                options.DefaultScheme = IdentityConstants.ApplicationScheme;
                options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
            }).AddIdentityCookies();       
        services.AddAuthorization();   
        services.AddControllers();
        services.AddInfrastructure(Configuration);
        services.AddApplication(Configuration);
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddIdentityAuthentication(Configuration);
    }

    public void Configure(IApplicationBuilder app
        , IWebHostEnvironment env)
    {
        // Configure the HTTP request pipeline.
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseRouting();

        app.UseAuthorization();
        
        app.UseEndpoints(x => x.MapControllers());
        app.UseEndpoints(x => 
            x.MapGroup("/identity")
             .MapIdentityApi<UserIdentity>());

    }
}