using Newtonsoft.Json;

namespace MyIdea.Youla.Models;

public class YoulaResponseDataFeedPageInfo
{
    [JsonProperty("hasNextPage")]
    public bool HasNextPage { get; set; }
}