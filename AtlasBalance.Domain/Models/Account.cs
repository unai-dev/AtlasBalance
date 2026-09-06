using System;
using System.Collections.Generic;
using System.Text;

using AtlasBalance.Domain.Models.Common;

namespace AtlasBalance.Domain.Models;

public class Account: BaseModel
{
    public string AccountName { get; set; } = null!;
    public string IBAN { get; set; } = null!;
    public double Amount { get; set; }
    public string Provider { get; set; } = null!;

    //related properties
    public User? User { get; set; } = null!;
    public int UserID { get; set; }
    public List<Expense> Expenses { get; set; } = new List<Expense>();
}
