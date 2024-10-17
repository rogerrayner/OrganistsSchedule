using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Infrastructure.Configurations;

public class EmailConfiguration: IEntityTypeConfiguration<Email>
{
    public void Configure(EntityTypeBuilder<Email> builder)
    {
        builder.ToTable("EMAILS");

        #region Index

        builder
            .HasIndex(x => x.Id)
            .IsUnique();
        
        builder
            .HasIndex(x => new
            {
                x.EmailAddress
            })
            .IsUnique()
            .HasDatabaseName("IX_EMAIL_ADDRESS");

        #endregion
        
        #region Keys
        builder
            .HasKey(x => x.Id);

        builder
            .HasAlternateKey(x => x.EmailAddress);
        #endregion
        
        #region Properties
        
        builder
            .Property(x => x.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();
        
        builder
            .Property(x => x.EmailAddress)
            .IsRequired()
            .HasMaxLength(200);
        
        #endregion
        
    }
}