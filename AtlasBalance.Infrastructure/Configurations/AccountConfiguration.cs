using System;
using System.Collections.Generic;
using System.Text;

using AtlasBalance.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasBalance.Infrastructure.Configurations;

public class AccountConfiguration: IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("accounts");

        builder.HasKey(x => x.ID);

        builder.Property(x => x.AccountName)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(x => x.IBAN)
            .HasMaxLength(34)
            .IsRequired();

        builder.Property(x => x.Provider)
            .HasMaxLength(255)
            .IsRequired();
    }
}
