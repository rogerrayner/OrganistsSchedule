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
            .HasIndex(x => x.RelatorioBrasCode)
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
            .HasOne(x => x.Address)
            .WithOne()
            .HasForeignKey<Congregation>(x => x.AddressId)
            .OnDelete(DeleteBehavior.Cascade); 
        
        #endregion
        
        #region Properties
        builder
            .Property(x => x.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder
            .Property(x => x.RelatorioBrasCode)
            .IsRequired();

        builder
            .Property(x => x.Name)
            .HasMaxLength(70);

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