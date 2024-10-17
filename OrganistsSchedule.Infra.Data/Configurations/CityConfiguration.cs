using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Infrastructure.Seeds;

namespace OrganistsSchedule.Infrastructure.Configurations;

public class CityConfiguration: IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.ToTable("CITIES");

        #region Index

        builder
            .HasIndex(x => x.Id)
            .IsUnique();
        
        builder
            .HasIndex(x => x.Name)
            .IsUnique()
            .HasDatabaseName("IX_CITY_NAME_UNIQUE");

        #endregion
        
        #region Keys
        
        builder
            .HasKey(x => x.Id);
        builder
            .HasAlternateKey(x => x.Name);
        
        #endregion
        
        #region Properties
        builder
            .Property(x => x.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder
            .Property(x => x.Name)
            .HasMaxLength(150)
            .IsRequired();
        
        #endregion
        
        #region Relationships

        builder
            .HasOne(x => x.Country);

        #endregion
        
        #region Seeds
        
        builder.HasData(
            CitySeed.Cities);
        
        #endregion
    }
}