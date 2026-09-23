using AtlasBalance.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasBalance.Infrastructure.Configurations;

public class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
{
    public void Configure(EntityTypeBuilder<Expense> builder)
    {
        builder.ToTable("asp_Expenses");

        builder.HasKey(x => x.ID);

        builder.Property(x => x.Amount)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasMaxLength(2000)
            .IsRequired();

        builder.HasOne(x => x.ExpensesGroup)
            .WithMany(x => x.Expenses)
            .HasForeignKey(x => x.ExpensesGroupID)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Account)
            .WithMany(x => x.Expenses)
            .HasForeignKey(x => x.AccountID)
            .OnDelete(DeleteBehavior.Restrict);


        builder.HasOne(x => x.Category)
            .WithMany(x => x.Expenses)
            .HasForeignKey(x => x.CategoryID)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.User)
            .WithMany(x => x.Expenses)
            .HasForeignKey(x => x.UserID)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.PaymentMethod)
            .WithMany(x => x.Expenses)
            .HasForeignKey(x => x.PaymentMethodID)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
