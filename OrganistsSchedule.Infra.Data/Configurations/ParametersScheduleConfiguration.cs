using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Infrastructure.Configurations;

public class ParametersScheduleConfiguration: IEntityTypeConfiguration<ParameterSchedule>
{
    public void Configure(EntityTypeBuilder<ParameterSchedule> builder)
    {
        builder.ToTable("PARAMETERS_SCHEDULE");

        #region Index

        builder
            .HasIndex(x => x.Id)
            .IsUnique();
        builder
            .HasIndex(x => new
            {
                x.StartDate,
                x.EndDate,
                x.CongregationId
            })
            .HasDatabaseName("IX_CONGREGATION_RANGE_DATE");

        #endregion
        
        #region Keys
        
        builder
            .HasKey(x => x.Id);
        
        #endregion
        
        #region Relationships

        builder
            .HasOne(x => x.Congregation);

        #endregion
        
        #region Properties
        builder
            .Property(x => x.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder
            .Property(x => x.StartDate)
            .IsRequired();

        builder
            .Property(x => x.EndDate)
            .IsRequired();
        
        #endregion
    }
}