using System;
using System.Collections.Generic;
using AtlasBalance.Application.DTOs.User;
using AtlasBalance.Application.DTOs.Expense;

namespace AtlasBalance.Application.DTOs.Account;

public class AccountReadWithRelationsDto : AccountReadDto
{
    public UserReadDto? User { get; set; }

    public List<ExpenseReadDto> Expenses { get; set; } = new List<ExpenseReadDto>();
}
