using Microsoft.AspNetCore.Identity;

namespace AtlasBalance.Domain.Models;

public class User: IdentityUser<int>
{
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    //related properties
    public List<Account> Accounts { get; set; } = new List<Account>();
    public List<Expense> Expenses { get; set; } = new List<Expense>();
}
