using Newtonsoft.Json;

namespace MyIdea.Youla.Models;

public class YoulaResponseDataFeedItem
{
    [JsonProperty("product")]
    public YoulaResponseDataFeedItemProduct? Product { get; set; }
}