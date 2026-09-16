using System;
using System.ComponentModel.DataAnnotations;

namespace AtlasBalance.Application.DTOs.PaymentMethod;

public class PaymentMethodUpdateDto
{
    [StringLength(55)]
    public string? MethodType { get; set; }

    [StringLength(255)]
    public string? ProviderName { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
