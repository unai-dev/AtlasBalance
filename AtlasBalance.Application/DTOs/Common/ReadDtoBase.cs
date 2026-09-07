using System;

namespace AtlasBalance.Application.DTOs.Common;

public abstract class ReadDtoBase
{
    public int ID { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
