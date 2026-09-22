using System;
using System.Collections.Generic;
using System.Text;

using AtlasBalance.Domain.Models.Common;

namespace AtlasBalance.Domain.Models;

public class Account : BaseModel
{
    #region Properties
    public string AccountName { get; set; } = null!;
    public string IBAN { get; set; } = null!;
    public double Amount { get; set; }
    public string Provider { get; set; } = null!;
    #endregion

    #region Related Properties
    public User? User { get; set; } = null!;
    public int UserID { get; set; }
    public List<Expense> Expenses { get; set; } = new List<Expense>();
    public List<Transfer> Transfers { get; set; } = new List<Transfer>();
    #endregion
}
