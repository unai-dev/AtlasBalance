using System;
using System.ComponentModel.DataAnnotations;

namespace AtlasBalance.Application.DTOs.Transfer;

public class TransferCreateDto
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

    [Required]
    [StringLength(55)]
    public string Addressee { get; set; } = null!;

    [Required]
    [StringLength(55)]
    public string Sender { get; set; } = null!;

    public DateTime MovementDate { get; set; }
}
