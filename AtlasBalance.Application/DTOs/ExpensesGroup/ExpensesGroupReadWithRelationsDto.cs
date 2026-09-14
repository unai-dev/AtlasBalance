using System;
using System.Collections.Generic;
using AtlasBalance.Application.DTOs.Common;
using AtlasBalance.Application.DTOs.User;
using AtlasBalance.Application.DTOs.Category;
using AtlasBalance.Application.DTOs.Expense;

namespace AtlasBalance.Application.DTOs.ExpensesGroup;

public class ExpensesGroupReadWithRelationsDto : ExpensesGroupReadDto
{
    public UserReadDto? Owner { get; set; }

    public UserReadDto? Guest { get; set; }

    public CategoryReadDto? Category { get; set; }

    public List<ExpenseReadDto> Expenses { get; set; } = new List<ExpenseReadDto>();
}
