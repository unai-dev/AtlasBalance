using System;
using System.Collections.Generic;
using System.Text;

using AtlasBalance.Domain.Models.Common;

namespace AtlasBalance.Domain.Models;

public class Currency : BaseModel
{
    #region Properties
    public string CodeISO { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Symbol { get; set; } = null!;
    #endregion

    #region Related Properties
    public List<Expense> Expenses { get; set; } = new List<Expense>();
    public List<Transfer> Transfers { get; set; } = new List<Transfer>();
    #endregion

}