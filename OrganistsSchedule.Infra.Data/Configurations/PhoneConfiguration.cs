using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Infrastructure.Configurations;

public class PhoneConfiguration: IEntityTypeConfiguration<Phone>
{
    public void Configure(EntityTypeBuilder<Phone> builder)
    {
        builder.ToTable("PHONES");

        #region Index

        builder
            .HasIndex(x => x.Id)
            .IsUnique();
        
        builder
            .HasIndex(x => new
            {
                x.Number
            })
            .IsUnique()
            .HasDatabaseName("IX_PHONE_NUMBER");

        #endregion
        
        #region Keys
        builder
            .HasKey(x => x.Id);

        builder
            .HasAlternateKey(x => x.Number);
        #endregion
        
        #region Properties
        
        builder
            .Property(x => x.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();
        
        builder
            .Property(x => x.Number)
            .IsRequired();
        
        #endregion
    }
}