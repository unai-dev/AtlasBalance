using AtlasBalance.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasBalance.Infrastructure.Configurations;

public class TransferConfiguration : IEntityTypeConfiguration<Transfer>
{
    public void Configure(EntityTypeBuilder<Transfer> builder)
    {
        builder.ToTable("asp_Transfers");

        builder.HasKey(x => x.ID);

        builder.Property(x => x.Amount)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasMaxLength(2000)
            .IsRequired();

        builder.Property(x => x.Addressee)
            .HasMaxLength(55)
            .IsRequired();

        builder.Property(x => x.Sender)
            .HasMaxLength(55)
            .IsRequired();


        builder.HasOne(x => x.Account)
            .WithMany(x => x.Transfers)
            .HasForeignKey(x => x.AccountID)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Category)
            .WithMany(x => x.Transfers)
            .HasForeignKey(x => x.CategoryID)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.User)
            .WithMany(x => x.Transfers)
            .HasForeignKey(x => x.UserID)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.PaymentMethod)
            .WithMany(x => x.Transfers)
            .HasForeignKey(x => x.PaymentMethodID)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
