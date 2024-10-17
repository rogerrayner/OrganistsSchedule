using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Infrastructure.Seeds;

namespace OrganistsSchedule.Infrastructure.Configurations;

public class OrganistConfiguration: IEntityTypeConfiguration<Organist>
{
    public void Configure(EntityTypeBuilder<Organist> builder)
    {
        builder.ToTable("ORGANISTS");

        #region Index

        builder
            .HasIndex(x => x.Id)
            .IsUnique();
        builder
            .HasIndex(x => new
            {
                x.ShortName,
                x.FullName
            })
            .HasDatabaseName("IX_ORGANISTS_NAMES");

        #endregion
        
        #region Keys
        
        builder
            .HasKey(x => x.Id);
        builder
            .HasAlternateKey(x => x.Cpf);
        
        #endregion
        
        #region Properties
        builder
            .Property(x => x.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder
            .Property(x => x.Cpf)
            .HasMaxLength(11);

        builder
            .Property(x => x.FullName)
            .HasMaxLength(200);

        builder
            .Property(x => x.ShortName)
            .IsRequired()
            .HasMaxLength(30);
        
        #endregion
        
        #region Relationships

        builder
            .HasOne(x => x.Address)
            .WithOne(x => x.Organist)
            .HasForeignKey<Address>(x => x.OrganistId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany<Email>(x => x.Emails)
            .WithOne(x => x.Organist)
            .HasForeignKey(x => x.OrganistId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder
            .HasOne(x => x.PhoneNumber)
            .WithOne(x => x.Organist)
            .HasForeignKey<Phone>(x => x.OrganistId)
            .OnDelete(DeleteBehavior.Cascade);
        
        #endregion
        
        #region Seeds
        
        builder.HasData(
            OrganistSeed.Organists);
        
        #endregion
    }
}