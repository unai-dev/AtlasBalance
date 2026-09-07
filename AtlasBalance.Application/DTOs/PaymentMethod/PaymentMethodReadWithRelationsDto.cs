using System;
using System.Collections.Generic;
using AtlasBalance.Application.DTOs.Expense;

namespace AtlasBalance.Application.DTOs.PaymentMethod;

public class PaymentMethodReadWithRelationsDto : PaymentMethodReadDto
{
    public List<ExpenseReadDto> Expenses { get; set; } = new List<ExpenseReadDto>();
}
