using System;
using System.Collections.Generic;
using System.Text;

using AtlasBalance.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace AtlasBalance.Infrastructure.Configurations;

public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
{
    public void Configure(EntityTypeBuilder<Currency> builder)
    {
        builder.ToTable("currencies");

        builder.HasKey(x => x.ID);

        builder.Property(x => x.CodeISO)
            .HasMaxLength(3)
            .IsRequired();

        builder.Property(x => x.Name)
            .HasMaxLength(55)
            .IsRequired();

        builder.Property(x => x.Symbol)
            .HasMaxLength(1)
            .IsRequired();

        // Seed default currencies
        builder.HasData(
            new Currency { ID = 1, CodeISO = "USD", Name = "US Dollar", Symbol = "$", CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new Currency { ID = 2, CodeISO = "EUR", Name = "Euro", Symbol = "€", CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new Currency { ID = 3, CodeISO = "GBP", Name = "Pound Sterling", Symbol = "£", CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new Currency { ID = 4, CodeISO = "JPY", Name = "Japanese Yen", Symbol = "¥", CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc) }
        );
    }
}
