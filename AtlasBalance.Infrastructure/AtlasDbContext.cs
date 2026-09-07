using System;
using System.Collections.Generic;
using System.Text;

using AtlasBalance.Domain.Models;
using AtlasBalance.Infrastructure.Configurations;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AtlasBalance.Infrastructure;

public class AtlasDbContext : IdentityDbContext<User, IdentityRole<int>, int>
{
    public AtlasDbContext(DbContextOptions<AtlasDbContext> options) : base(options) { }

    /**
     | * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
     |                                          DB SETS
     | * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
     */
    public DbSet<Expense> Expenses => Set<Expense>();
    public DbSet<Currency> Currencies => Set<Currency>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<PaymentMethod> PaymentMethods => Set<PaymentMethod>();
    public DbSet<Account> Accounts => Set<Account>();

    /// <summary>
    /// Override the OnModelCreating method to apply entity configurations for the database context.
    /// </summary>
    /// <param name="builder">The ModelBuilder instance</param>
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new ExpenseConfiguration());
        builder.ApplyConfiguration(new CurrencyConfiguration());
        builder.ApplyConfiguration(new CategoryConfiguration());
        builder.ApplyConfiguration(new PaymentMethodConfiguration());
        builder.ApplyConfiguration(new AccountConfiguration());
    }
}
