using System;
using System.ComponentModel.DataAnnotations;

namespace AtlasBalance.Application.DTOs.Account;

public class AccountUpdateDto
{
    [Required]
    [StringLength(255)]
    public string AccountName { get; set; } = null!;

    [Required]
    [StringLength(34)]
    public string IBAN { get; set; } = null!;

    public double Amount { get; set; }

    [Required]
    [StringLength(255)]
    public string Provider { get; set; } = null!;

    public int UserID { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
