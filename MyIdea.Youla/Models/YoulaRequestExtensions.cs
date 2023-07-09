using Newtonsoft.Json;

namespace MyIdea.Youla.Models;

public class YoulaRequestExtensions
{
    [JsonProperty("persistedQuery")]
    public YoulaRequestExtensionsPersistedQuery PersistedQuery { get; set; }
}