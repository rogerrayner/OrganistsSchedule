using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Infrastructure.Seeds;

namespace OrganistsSchedule.Infrastructure.Configurations;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("ADDRESS");

        builder.HasIndex(x => x.Id).IsUnique();
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Property(x => x.StreetNumber).IsRequired();
        builder.Property(x => x.Complement).HasMaxLength(100);
        
        builder
            .HasOne(x => x.Cep)
            .WithMany()
            .HasForeignKey(x => x.CepId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict); 

        builder.HasData(AddressSeed.IndividualAddresses);
    }
}