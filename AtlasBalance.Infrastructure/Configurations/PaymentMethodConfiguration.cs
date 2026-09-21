using AtlasBalance.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasBalance.Infrastructure.Configurations;

public class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
{
    public void Configure(EntityTypeBuilder<PaymentMethod> builder)
    {
        builder.ToTable("asp_PaymentMethods");

        builder.HasKey(x => x.ID);

        builder.Property(x => x.MethodType)
            .HasMaxLength(55);

        builder.Property(x => x.ProviderName)
            .HasMaxLength(255)
            .IsRequired();

        // Seed default payment methods
        builder.HasData(
            new PaymentMethod { ID = 1, MethodType = "Cash", ProviderName = "General", CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new PaymentMethod { ID = 2, MethodType = "Card", ProviderName = "Visa", CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new PaymentMethod { ID = 3, MethodType = "Card", ProviderName = "Mastercard", CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new PaymentMethod { ID = 4, MethodType = "BankTransfer", ProviderName = "SEPA", CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc) }
        );
    }
}
