using System;
using System.ComponentModel.DataAnnotations;

namespace AtlasBalance.Application.DTOs.Expense;

public class ExpenseUpdateDto
{
    public double Amount { get; set; }

    [Required]
    [StringLength(2000)]
    public string Description { get; set; } = null!;

    public int UserID { get; set; }

    public int CurrencyID { get; set; }

    public int CategoryID { get; set; }

    public int PaymentMethodID { get; set; }

    public int AccountID { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
