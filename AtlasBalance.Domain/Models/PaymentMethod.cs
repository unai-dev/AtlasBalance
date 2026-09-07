using System;
using System.Collections.Generic;
using System.Text;

using AtlasBalance.Domain.Models.Common;

namespace AtlasBalance.Domain.Models;

public class PaymentMethod : BaseModel
{
    //properties
    public string MethodType { get; set; } = null!;
    public string ProviderName { get; set; } = null!;

    //related properties
    public List<Expense> Expenses { get; set; } = new List<Expense>();
}
