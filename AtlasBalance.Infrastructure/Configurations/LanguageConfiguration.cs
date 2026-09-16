using AtlasBalance.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasBalance.Infrastructure.Configurations;

public class LanguageConfiguration: IEntityTypeConfiguration<Language>
{
    public void Configure(EntityTypeBuilder<Language> builder)
    {
        builder.ToTable("languages");

        builder.HasKey(x => x.ID);

        builder.Property(x => x.Code)
            .HasMaxLength(2)
            .IsRequired();

        builder.Property(x => x.Name)
            .HasMaxLength(55)
            .IsRequired();
    }
}
