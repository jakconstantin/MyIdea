using Newtonsoft.Json;

namespace Idea.Youla.Models;

public class YoulaResponseDataFeed
{
    [JsonProperty("items")]
    public List<YoulaResponseDataFeedItem> Items { get; set; }

    [JsonProperty("pageInfo")]
    public YoulaResponseDataFeedPageInfo PageInfo { get; set; }
}