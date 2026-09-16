using System;
using System.ComponentModel.DataAnnotations;

namespace AtlasBalance.Application.DTOs.Currency;

public class CurrencyUpdateDto
{
    [StringLength(3)]
    public string? CodeISO { get; set; }

    [StringLength(55)]
    public string? Name { get; set; }

    [StringLength(1)]
    public string? Symbol { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
