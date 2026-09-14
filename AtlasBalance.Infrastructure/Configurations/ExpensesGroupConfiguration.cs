using AtlasBalance.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasBalance.Infrastructure.Configurations;

public class ExpensesGroupConfiguration: IEntityTypeConfiguration<ExpensesGroup>
{
    public void Configure(EntityTypeBuilder<ExpensesGroup> builder)
    {
        builder.ToTable("expenses_groups");

        builder.HasKey(x => x.ID);

        builder.Property(x => x.Name)
            .HasMaxLength(55)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasMaxLength(2000)
            .IsRequired();
    }
}
