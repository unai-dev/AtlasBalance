using System;
using System.Collections.Generic;
using AtlasBalance.Application.DTOs.Expense;

namespace AtlasBalance.Application.DTOs.Category;

public class CategoryReadWithRelationsDto : CategoryReadDto
{
    public List<ExpenseReadDto> Expenses { get; set; } = new List<ExpenseReadDto>();
}
