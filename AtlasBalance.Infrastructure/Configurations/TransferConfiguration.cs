using AtlasBalance.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasBalance.Infrastructure.Configurations;

public class TransferConfiguration: IEntityTypeConfiguration<Transfer>
{
    public void Configure(EntityTypeBuilder<Transfer> builder)
    {
        builder.ToTable("transfers");

        builder.HasKey(x => x.ID);

        builder.Property(x => x.Addressee)
            .HasMaxLength(55)
            .IsRequired();
        
        builder.Property(x => x.Sender)
            .HasMaxLength(55)
            .IsRequired();
    }
}
