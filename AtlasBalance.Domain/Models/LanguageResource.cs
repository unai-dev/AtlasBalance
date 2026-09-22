using AtlasBalance.Domain.Models.Common;

namespace AtlasBalance.Domain.Models;

public class LanguageResource : BaseModel
{
    #region Properties
    public string Text = null!;
    public string Description = null!;
    #endregion

    #region Related Properties
    public int LanguageID { get; set; }
    public Language? Language { get; set; }
    #endregion
}
