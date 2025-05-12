using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Infrastructure.Configurations;

public class HolyServiceConfiguration : IEntityTypeConfiguration<HolyService>
{
    public void Configure(EntityTypeBuilder<HolyService> builder)
    {
        builder.ToTable("HOLY_SERVICES");

        #region Index
        
        builder
            .HasIndex(x => x.Id)
            .IsUnique();
        builder
            .HasIndex(x => new
            {
                x.Date,
                x.CongregationId,
                x.OrganistId
            })
            .IsUnique()
            .HasDatabaseName("IX_DATE_OF_HOLY_SERVICE");
        
        #endregion
        
        #region Properties

        builder
            .Property(x => x.Date)
            .IsRequired()
            .ValueGeneratedNever();

        builder
            .Property(x => x.IsYouthMeeting)
            .IsRequired();

        #endregion

        #region Relationships

        builder
            .HasOne(x => x.Congregation)
            .WithMany()
            .HasForeignKey(x => x.CongregationId);

        builder
            .HasOne(x => x.Organist)
            .WithMany()
            .HasForeignKey(x => x.OrganistId);

        #endregion
    }
}