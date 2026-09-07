using System.ComponentModel.DataAnnotations;

namespace AtlasBalance.Application.DTOs.PaymentMethod;

public class PaymentMethodCreateDto
{
    [Required]
    [StringLength(55)]
    public string MethodType { get; set; } = null!;

    [Required]
    [StringLength(255)]
    public string ProviderName { get; set; } = null!;
}
