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

        // Seed default categories required by the application
        builder.HasData(
            new Category { ID = 1, Name = "Food", CreatedAt = DateTime.UtcNow },
            new Category { ID = 2, Name = "Transport", CreatedAt = DateTime.UtcNow },
            new Category { ID = 3, Name = "Utilities", CreatedAt = DateTime.UtcNow },
            new Category { ID = 4, Name = "Entertainment", CreatedAt = DateTime.UtcNow },
            new Category { ID = 5, Name = "Health", CreatedAt = DateTime.UtcNow },
            new Category { ID = 6, Name = "Education", CreatedAt = DateTime.UtcNow },
            new Category { ID = 7, Name = "Shopping", CreatedAt = DateTime.UtcNow },
            new Category { ID = 8, Name = "Others", CreatedAt = DateTime.UtcNow }
        );
    }
}
