using System;
using System.Collections.Generic;
using System.Text;

using AtlasBalance.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasBalance.Infrastructure.Configurations;

public class CategoryConfiguration: IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("categories");

        builder.HasKey(x => x.ID);

        builder.Property(x => x.Name)
            .HasMaxLength(55)
            .IsRequired();
    }
}
