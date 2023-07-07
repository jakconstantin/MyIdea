using Newtonsoft.Json;

namespace Idea.Youla.Models;

public class YoulaRequestExtensionsPersistedQuery
{
    [JsonProperty("version")]
    public int Version { get; set; }

    [JsonProperty("sha256Hash")]
    public string Sha256Hash { get; set; }
}