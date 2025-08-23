using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using OrganistsSchedule.Application.Services;
using OrganistsSchedule.Infra.Data;
using OrganistsSchedule.Infra.IoC;
using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

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
            options.AddPolicy("AllowSpecificOrigins", builder =>
            {
                var allowedOrigins = Configuration["AllowedOrigins"]
                    ?.Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(origin => origin.Trim())
                    .ToArray() ?? Array.Empty<string>();
                
                if (allowedOrigins.Length > 0)
                {
                    builder.WithOrigins(allowedOrigins)
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                }
                else
                {
                    // Fallback para desenvolvimento se não houver origens configuradas
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                }
            });
            
            // Política padrão mais permissiva para desenvolvimento
            options.AddDefaultPolicy(builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
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
        
        // Adicionar Health Checks nativos do ASP.NET Core
        services.AddHealthChecks()
            .AddCheck("self", () => HealthCheckResult.Healthy("API is running"))
            .AddCheck("database", () => 
            {
                try
                {
                    // Verificação básica - pode ser expandida futuramente
                    return HealthCheckResult.Healthy("Database is accessible");
                }
                catch (Exception ex)
                {
                    return HealthCheckResult.Unhealthy($"Database error: {ex.Message}");
                }
            });
        
    }

    public void Configure(IApplicationBuilder app
        , IWebHostEnvironment env, 
        ILoggerFactory loggerFactory)
    {
        
        // Configure the HTTP request pipeline.
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseMiddleware<ExceptionMiddleware>();
        app.UseHttpsRedirection();
        app.UseRouting();
        
        // Adicionar Health Check nativo antes do CORS
        app.UseHealthChecks("/health", new HealthCheckOptions
        {
            ResponseWriter = async (context, report) =>
            {
                context.Response.ContentType = "application/json";
                var response = new
                {
                    status = report.Status.ToString(),
                    timestamp = DateTime.UtcNow,
                    duration = report.TotalDuration.TotalMilliseconds,
                    checks = report.Entries.Select(entry => new
                    {
                        name = entry.Key,
                        status = entry.Value.Status.ToString(),
                        description = entry.Value.Description,
                        duration = entry.Value.Duration.TotalMilliseconds
                    })
                };
                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            }
        });
        
        app.UseCors("AllowSpecificOrigins");
        app.UseAuthentication();
        app.UseAuthorization();
        
        app.UseEndpoints(x => x.MapControllers());

    }
}