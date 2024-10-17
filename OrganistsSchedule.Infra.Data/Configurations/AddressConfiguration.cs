using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Infrastructure.Seeds;

namespace OrganistsSchedule.Infrastructure.Configurations;

public class AddressConfiguration: IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("ADDRESS");

        #region Index

        builder
            .HasIndex(x => x.Id)
            .IsUnique();
        
        #endregion
        
        #region Keys
        
        builder
            .HasKey(x => x.Id);
        
        #endregion
        
        #region Properties
        builder
            .Property(x => x.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder
            .Property(x => x.StreetNumber)
            .IsRequired();

        builder
            .Property(x => x.Complement)
            .HasMaxLength(200);
        
        #endregion

        #region Relationships
        
        builder
            .HasOne(x => x.Cep)
            .WithMany(x => x.Addresses)
            .HasForeignKey(x => x.CepId);
        
        #endregion
        
        #region Seeds
        
        builder.HasData(
            AddressSeed.IndividualAddresses);
        
        #endregion
    }
}