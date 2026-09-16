using System;
using System.ComponentModel.DataAnnotations;

namespace AtlasBalance.Application.DTOs.Account;

public class AccountUpdateDto
{
    [StringLength(255)]
    public string? AccountName { get; set; }

    [StringLength(34)]
    public string? IBAN { get; set; }

    public double? Amount { get; set; }

    [StringLength(255)]
    public string? Provider { get; set; }

    public int? UserID { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
