using Newtonsoft.Json;

namespace Idea.Youla.Models;

public class YoulaRequestExtensions
{
    [JsonProperty("persistedQuery")]
    public YoulaRequestExtensionsPersistedQuery PersistedQuery { get; set; }
}