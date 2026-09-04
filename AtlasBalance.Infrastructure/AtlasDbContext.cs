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

    public DbSet<Expense> Expenses => Set<Expense>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new ExpenseConfiguration());
    }
}
