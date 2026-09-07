using System;
using System.ComponentModel.DataAnnotations;

namespace AtlasBalance.Application.DTOs.PaymentMethod;

public class PaymentMethodUpdateDto
{
    [Required]
    [StringLength(55)]
    public string MethodType { get; set; } = null!;

    [StringLength(255)]
    public string ProviderName { get; set; } = null!;

    public DateTime? UpdatedAt { get; set; }
}
