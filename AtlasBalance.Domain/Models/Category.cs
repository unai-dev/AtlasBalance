using System;
using System.Collections.Generic;
using System.Text;

namespace AtlasBalance.Domain.Models;

public class Category: BaseModel
{
    public string Name { get; set; } = null!;

    //related properties
    public List<Expense> Expenses { get; set; } = new List<Expense>();
}
