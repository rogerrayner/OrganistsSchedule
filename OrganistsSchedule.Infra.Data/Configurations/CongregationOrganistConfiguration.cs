using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CongregationOrganistConfiguration : IEntityTypeConfiguration<CongregationOrganist>
{
    public void Configure(EntityTypeBuilder<CongregationOrganist> builder)
    {
        builder.ToTable("CONGREGATION_ORGANISTS");

        builder.HasKey(co => new { co.CongregationId, co.OrganistId });

        builder
            .HasOne(co => co.Congregation)
            .WithMany(c => c.CongregationOrganists)
            .HasForeignKey(co => co.CongregationId);

        builder
            .HasOne(co => co.Organist)
            .WithMany(o => o.CongregationOrganists)
            .HasForeignKey(co => co.OrganistId);

        builder
            .Property(co => co.OrganistServiceDaysOfWeek)
            .IsRequired();
    }
}