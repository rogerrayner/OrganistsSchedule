using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Infrastructure.Seeds;

namespace OrganistsSchedule.Infrastructure.Configurations;

public class CepConfiguration: IEntityTypeConfiguration<Cep>
{
    public void Configure(EntityTypeBuilder<Cep> builder)
    {
        builder.ToTable("CEPS");

        #region Index

        builder
            .HasIndex(x => x.Id)
            .IsUnique();
        
        builder
            .HasIndex(x => x.ZipCode)
            .IsUnique()
            .HasDatabaseName("IX_CEP_UNIQUE");

        #endregion
        
        #region Keys
        
        builder
            .HasKey(x => x.Id);
        builder
            .HasAlternateKey(x => x.ZipCode);
        
        #endregion
        
        #region Properties
        builder
            .Property(x => x.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder
            .Property(x => x.ZipCode)
            .HasMaxLength(10)
            .IsRequired();

        builder
            .Property(x => x.Street)
            .HasMaxLength(70)
            .IsRequired();

        builder
            .Property(x => x.District)
            .IsRequired()
            .HasMaxLength(70);
        
        builder
            .Property(x => x.State)
            .IsRequired()
            .HasMaxLength(40);
        
        #endregion
        
        #region Relationships

        builder
            .HasOne(x => x.City)
            .WithMany()
            .HasForeignKey(x => x.CityId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        #endregion
        
        #region Seeds
        builder.HasData(
            CepSeed.Addresses);
        #endregion
    }
}