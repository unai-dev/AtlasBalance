using System;
using System.Collections.Generic;
using System.Text;

using AtlasBalance.Domain.Models.Common;

namespace AtlasBalance.Domain.Models;

public class ExpensesGroup : BaseModel
{
    #region Properties
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    #endregion

    #region Related Properties
    public int OwnerID { get; set; }
    public User? Owner { get; set; }

    public int GuestID { get; set; }
    public User? Guest { get; set; }

    public int CategoryID { get; set; }
    public Category? Category { get; set; }

    public List<Expense> Expenses { get; set; } = new List<Expense>();
    public List<Transfer> Transfers { get; set; } = new List<Transfer>();
    #endregion
}
