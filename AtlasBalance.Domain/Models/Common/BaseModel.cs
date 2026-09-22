using System;
using System.Collections.Generic;
using System.Text;

namespace AtlasBalance.Domain.Models.Common;

public abstract class BaseModel
{
    #region Properties
    public int ID { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
    #endregion
}
