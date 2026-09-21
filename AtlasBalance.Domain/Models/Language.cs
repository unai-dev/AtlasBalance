using AtlasBalance.Domain.Models.Common;

namespace AtlasBalance.Domain.Models;

public class Language: BaseModel
{
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;

    //related properties
    public List<User> Users { get; set; } = new List<User>();
    public List<LanguageResource> LanguageResources = new List<LanguageResource>();

}
