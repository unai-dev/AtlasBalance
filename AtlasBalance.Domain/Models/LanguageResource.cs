using AtlasBalance.Domain.Models.Common;

namespace AtlasBalance.Domain.Models;

public class LanguageResource: BaseModel
{
    public string Text = null!;
    public string Description = null!;

    //related properties
    public int LanguageID { get; set; }
    public Language? Language { get; set; }
}
