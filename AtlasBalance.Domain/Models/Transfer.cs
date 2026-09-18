using AtlasBalance.Domain.Models.Common;

namespace AtlasBalance.Domain.Models;

public class Transfer: Movement
{
    public string Addressee { get; set; } = null!;
    public string Sender { get; set; } = null!;
}
