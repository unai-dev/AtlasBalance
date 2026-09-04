using System;
using System.Collections.Generic;
using System.Text;

using AtlasBalance.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace AtlasBalance.Infrastructure.Configurations;

public class CurrencyConfiguration: IEntityTypeConfiguration<Currency>
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
    }  
}
