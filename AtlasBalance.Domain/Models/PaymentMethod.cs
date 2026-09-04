using System;
using System.Collections.Generic;
using System.Text;

namespace AtlasBalance.Domain.Models;

public class PaymentMethod : BaseModel
{
    public string MethodType { get; set; } = null!;
    public string ProviderName { get; set; } = null!;

    //related properties
    public List<PaymentMethod> PaymentMethods { get; set; } = new List<PaymentMethod>();
}
