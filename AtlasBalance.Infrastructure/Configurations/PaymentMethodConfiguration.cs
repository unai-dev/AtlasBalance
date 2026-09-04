using AtlasBalance.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasBalance.Infrastructure.Configurations;

public class PaymentMethodConfiguration: IEntityTypeConfiguration<PaymentMethod>
{
    public void Configure(EntityTypeBuilder<PaymentMethod> builder)
    {
        builder.ToTable("payment_methods");

        builder.HasKey(x => x.ID);

        builder.Property(x => x.MethodType)
            .HasMaxLength(55);

        builder.Property(x => x.ProviderName)
            .HasMaxLength(255)
            .IsRequired();
    }
}
