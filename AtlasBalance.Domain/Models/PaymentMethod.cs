using System;
using System.Collections.Generic;
using System.Text;

using AtlasBalance.Domain.Models.Common;

namespace AtlasBalance.Domain.Models;

public class PaymentMethod : BaseModel
{
    #region Properties
    public string MethodType { get; set; } = null!;
    public string ProviderName { get; set; } = null!;
    #endregion

    #region Related Properties
    public List<Expense> Expenses { get; set; } = new List<Expense>();
    public List<Transfer> Transfers { get; set; } = new List<Transfer>();
    #endregion
}
