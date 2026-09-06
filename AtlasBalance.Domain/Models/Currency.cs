using System;
using System.Collections.Generic;
using System.Text;

using AtlasBalance.Domain.Models.Common;

namespace AtlasBalance.Domain.Models;

public class Currency : BaseModel
{
    public string CodeISO { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Symbol { get; set; } = null!;

    //related properties
    public List<Expense> Expenses { get; set; } = new List<Expense>();

}