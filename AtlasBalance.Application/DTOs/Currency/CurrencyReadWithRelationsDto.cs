using System;
using System.Collections.Generic;
using AtlasBalance.Application.DTOs.Expense;

namespace AtlasBalance.Application.DTOs.Currency;

public class CurrencyReadWithRelationsDto : CurrencyReadDto
{
    public List<ExpenseReadDto> Expenses { get; set; } = new List<ExpenseReadDto>();
}
