using System;
using AtlasBalance.Application.DTOs.User;
using AtlasBalance.Application.DTOs.Currency;
using AtlasBalance.Application.DTOs.Category;
using AtlasBalance.Application.DTOs.PaymentMethod;
using AtlasBalance.Application.DTOs.Account;

namespace AtlasBalance.Application.DTOs.Expense;

public class ExpenseReadWithRelationsDto : ExpenseReadDto
{
    public UserReadDto? User { get; set; }

    public CurrencyReadDto? Currency { get; set; }

    public CategoryReadDto? Category { get; set; }

    public PaymentMethodReadDto? PaymentMethod { get; set; }

    public AccountReadDto? Account { get; set; }
}
