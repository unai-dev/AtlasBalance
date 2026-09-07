using System.ComponentModel.DataAnnotations;

namespace AtlasBalance.Application.DTOs.Currency;

public class CurrencyCreateDto
{
    [Required]
    [StringLength(3)]
    public string CodeISO { get; set; } = null!;

    [Required]
    [StringLength(55)]
    public string Name { get; set; } = null!;

    [Required]
    [StringLength(1)]
    public string Symbol { get; set; } = null!;
}
