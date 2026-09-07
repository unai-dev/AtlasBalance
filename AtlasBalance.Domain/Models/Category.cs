using System;
using System.Collections.Generic;
using System.Text;

using AtlasBalance.Domain.Models.Common;

namespace AtlasBalance.Domain.Models;

public class Category: BaseModel
{
    //properties
    public string Name { get; set; } = null!;

    //related properties
    public List<Expense> Expenses { get; set; } = new List<Expense>();
}
