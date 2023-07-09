using Newtonsoft.Json;

namespace MyIdea.Youla.Models;

public class YoulaResponseData
{
    [JsonProperty("feed")]
    public YoulaResponseDataFeed? Feed { get; set; }
}