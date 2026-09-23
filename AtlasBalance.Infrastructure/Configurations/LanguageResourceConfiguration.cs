using AtlasBalance.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasBalance.Infrastructure.Configurations;

public class LanguageResourceConfiguration : IEntityTypeConfiguration<LanguageResource>
{
    public void Configure(EntityTypeBuilder<LanguageResource> builder)
    {
        builder.ToTable("asp_LanguageResources");

        builder.HasKey(x => x.ID);

        builder.Property(x => x.Text)
            .IsRequired();

        builder.Property(x => x.Description)
            .IsRequired();

        builder.HasOne(x => x.Language)
            .WithMany(x => x.LanguageResources)
            .HasForeignKey(x => x.LanguageID)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
