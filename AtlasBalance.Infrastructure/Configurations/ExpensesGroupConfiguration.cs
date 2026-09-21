using AtlasBalance.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasBalance.Infrastructure.Configurations;

public class ExpensesGroupConfiguration : IEntityTypeConfiguration<ExpensesGroup>
{
    public void Configure(EntityTypeBuilder<ExpensesGroup> builder)
    {
        builder.ToTable("asp_ExpensesGroups");

        builder.HasKey(x => x.ID);

        builder.Property(x => x.Name)
            .HasMaxLength(55)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasMaxLength(2000)
            .IsRequired();

        builder.HasOne(x => x.Owner)
            .WithMany(u => u.OwnedGroups)
            .HasForeignKey(x => x.OwnerID)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Guest)
            .WithMany(u => u.GuestGroups)
            .HasForeignKey(x => x.GuestID)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
