using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using OrganistsSchedule.Application.Services;
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
        
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                if (env == "Development")
                {
                    builder
                        .WithOrigins("http://localhost:3000")
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                }
                else
                {
                    builder
                        .WithOrigins("https://organist-schedule-front.onrender.com")
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                }
            });
        });
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.Audience = Configuration["Auth0:Audience"];
            options.Authority = Configuration["Auth0:Authority"];
            options.TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = ClaimTypes.NameIdentifier
                };
        });
        services.AddAuthorization(Configuration);
        services.AddControllers();
        services.AddInfrastructure(Configuration);
        services.AddApplication(Configuration);
        services.AddBackendForFrontend(Configuration);
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        
    }

    public void Configure(IApplicationBuilder app
        , IWebHostEnvironment env, 
        ILoggerFactory loggerFactory)
    {

        // Aplica as migrations automaticamente ao iniciar
        using (var scope = app.ApplicationServices.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<SeuDbContext>();
            db.Database.Migrate();
        }
        
        // Configure the HTTP request pipeline.
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseMiddleware<ExceptionMiddleware>();
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseCors();
        app.UseAuthentication();
        app.UseAuthorization();
        
        app.UseEndpoints(x => x.MapControllers());
        /*app.UseEndpoints(x => 
            x.MapGroup("/identity")
             .MapIdentityApi<UserIdentity>());*/

    }
}
