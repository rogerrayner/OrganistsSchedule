using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Infrastructure.Seeds;

namespace OrganistsSchedule.Infrastructure.Database.Configurations;

public class CongregationConfiguration : IEntityTypeConfiguration<Congregation>
{
    public void Configure(EntityTypeBuilder<Congregation> builder)
    {
        builder.ToTable("CONGREGATIONS");

        #region Index

        builder
            .HasIndex(x => x.Id)
            .IsUnique();
        builder
            .HasIndex(x => new
            {
                x.Name
            })
            .HasDatabaseName("IX_CONGREGATION_NAME");

        #endregion
        
        #region Keys
        
        builder
            .HasKey(x => x.Id);
        
        #endregion
        
        #region Relationships
        builder
            .HasMany(x => x.Organists)
            .WithOne(x => x.Congregation)
            .OnDelete(DeleteBehavior.Cascade);

        #endregion
        
        #region Properties
        builder
            .Property(x => x.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder
            .Property(x => x.Name)
            .HasMaxLength(200);

        builder
            .Property(x => x.HasYouthMeetings)
            .IsRequired()
            .HasDefaultValue(true);
        
        #endregion
        
        #region Seeds
        
        builder.HasData(
            CongregationSeed.Congregations);
        
        #endregion
    }
}