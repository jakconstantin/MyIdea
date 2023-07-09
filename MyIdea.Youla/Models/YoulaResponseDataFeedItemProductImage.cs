using Newtonsoft.Json;

namespace MyIdea.Youla.Models;

public class YoulaResponseDataFeedItemProductImage
{
    [JsonProperty("url")]
    public string Url { get; set; }
}