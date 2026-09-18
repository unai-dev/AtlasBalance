using System;
using System.ComponentModel.DataAnnotations;

namespace AtlasBalance.Application.DTOs.Transfer;

public class TransferUpdateDto
{
    public double Amount { get; set; }

    [StringLength(2000)]
    public string? Description { get; set; }

    public int? UserID { get; set; }

    public int? CurrencyID { get; set; }

    public int? CategoryID { get; set; }

    public int? PaymentMethodID { get; set; }

    public int? AccountID { get; set; }

    [StringLength(200)]
    public string? Addressee { get; set; }

    [StringLength(200)]
    public string? Sender { get; set; }

    public DateTime? MovementDate { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
