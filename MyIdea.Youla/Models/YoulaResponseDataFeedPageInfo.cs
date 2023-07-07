using Newtonsoft.Json;

namespace Idea.Youla.Models;

public class YoulaResponseDataFeedPageInfo
{
    [JsonProperty("hasNextPage")]
    public bool HasNextPage { get; set; }
}