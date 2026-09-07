using System;
using AtlasBalance.Application.DTOs.Common;

namespace AtlasBalance.Application.DTOs.Currency;

public class CurrencyReadDto : ReadDtoBase
{
    public string CodeISO { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Symbol { get; set; } = null!;
}
