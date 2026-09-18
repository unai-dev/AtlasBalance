using System;
using AtlasBalance.Application.DTOs.Common;

namespace AtlasBalance.Application.DTOs.Transfer;

public class TransferReadDto : ReadDtoBase
{
    public double Amount { get; set; }

    public string Description { get; set; } = null!;

    public int UserID { get; set; }

    public int CurrencyID { get; set; }

    public int CategoryID { get; set; }

    public int PaymentMethodID { get; set; }

    public int AccountID { get; set; }

    public string Addressee { get; set; } = null!;

    public string Sender { get; set; } = null!;

    public DateTime MovementDate { get; set; }
}
