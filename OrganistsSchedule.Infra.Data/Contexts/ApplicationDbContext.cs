using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Infra.Data.Identity;

namespace OrganistsSchedule.Infra.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<UserIdentity>(options)
{
    public virtual DbSet<Organist> Organists { get; set; }
    public virtual DbSet<Congregation> Congregations { get; set; }
    public virtual DbSet<HolyService> HolyServices { get; set; }
    public virtual DbSet<ParameterSchedule> ParametersSchedules { get; set; }
    public virtual DbSet<Cep> Ceps { get; set; }
    public virtual DbSet<City> Cities { get; set; }
    public virtual DbSet<Country> Countries { get; set; }
    public virtual DbSet<Address> IndividualAddresses { get; set; }
    public virtual DbSet<Email> Emails { get; set; }
    public virtual DbSet<Phone> Phones { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}