using Microsoft.AspNetCore.Identity;

namespace AtlasBalance.Domain.Models;

public class User : IdentityUser<int>
{
    #region Properties
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    #endregion

    #region Related Properties
    public int LanguageID { get; set; } = 1;
    public Language? Language { get; set; }

    public List<Account> Accounts { get; set; } = new List<Account>();
    public List<Expense> Expenses { get; set; } = new List<Expense>();
    public List<ExpensesGroup> OwnedGroups { get; set; } = new List<ExpensesGroup>();
    public List<ExpensesGroup> GuestGroups { get; set; } = new List<ExpensesGroup>();
    public List<Transfer> Transfers { get; set; } = new List<Transfer>();
    #endregion
}
