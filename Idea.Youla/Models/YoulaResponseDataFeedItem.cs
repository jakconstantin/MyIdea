using Newtonsoft.Json;

namespace Idea.Youla.Models;

public class YoulaResponseDataFeedItem
{
    [JsonProperty("product")]
    public YoulaResponseDataFeedItemProduct? Product { get; set; }
}