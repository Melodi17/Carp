using Newtonsoft.Json;

namespace Carp;

public class ProjectConfiguration
{
    public string Name { get; set; }
    public string Version { get; set; }
    public string Author { get; set; }
    
    public string? Icon { get; set; }
    
    public string Serialize() => JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
    public static ProjectConfiguration Deserialize(string json) => JsonConvert.DeserializeObject<ProjectConfiguration>(json)!;
}