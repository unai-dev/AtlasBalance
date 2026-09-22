using AtlasBalance.Domain.Models.Common;

namespace AtlasBalance.Domain.Models;

public class Expense : Movement
{
    #region Related Properties
    public ExpensesGroup? ExpensesGroup { get; set; }
    public int ExpensesGroupID { get; set; }
    #endregion
}
