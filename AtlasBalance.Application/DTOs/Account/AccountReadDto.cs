using System;
using AtlasBalance.Application.DTOs.Common;

namespace AtlasBalance.Application.DTOs.Account;

public class AccountReadDto : ReadDtoBase
{
    public string AccountName { get; set; } = null!;

    public string IBAN { get; set; } = null!;

    public double Amount { get; set; }

    public string Provider { get; set; } = null!;

    public int UserID { get; set; }
}
