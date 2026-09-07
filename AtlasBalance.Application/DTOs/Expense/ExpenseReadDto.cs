using System;
using AtlasBalance.Application.DTOs.Common;

namespace AtlasBalance.Application.DTOs.Expense;

public class ExpenseReadDto : ReadDtoBase
{
    public double Amount { get; set; }

    public string Description { get; set; } = null!;

    public int UserID { get; set; }

    public int CurrencyID { get; set; }

    public int CategoryID { get; set; }

    public int PaymentMethodID { get; set; }

    public int AccountID { get; set; }
}
