using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using OrganistsSchedule.Application.Services;
using OrganistsSchedule.Infra.Data;
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
        app.UseCors("AllowSpecificOrigins");
        app.UseAuthentication();
        app.UseAuthorization();
        
        app.UseEndpoints(x => x.MapControllers());

    }
}