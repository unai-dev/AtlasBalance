using System;
using AtlasBalance.Application.DTOs.Common;

namespace AtlasBalance.Application.DTOs.PaymentMethod;

public class PaymentMethodReadDto : ReadDtoBase
{
    public string MethodType { get; set; } = null!;

    public string ProviderName { get; set; } = null!;
}
