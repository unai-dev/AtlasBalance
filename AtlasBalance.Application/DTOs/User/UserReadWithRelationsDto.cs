using System;
using System.Collections.Generic;
using AtlasBalance.Application.DTOs.Account;
using AtlasBalance.Application.DTOs.Expense;

namespace AtlasBalance.Application.DTOs.User;

public class UserReadWithRelationsDto : UserReadDto
{
    public List<AccountReadDto> Accounts { get; set; } = new List<AccountReadDto>();

    public List<ExpenseReadDto> Expenses { get; set; } = new List<ExpenseReadDto>();
}
