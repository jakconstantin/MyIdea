using Newtonsoft.Json;

namespace Idea.Youla.Models;

public class YoulaResponseDataFeedItemProductImage
{
    [JsonProperty("url")]
    public string Url { get; set; }
}