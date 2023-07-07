using Newtonsoft.Json;

namespace Idea.Youla.Models;

public class YoulaResponseData
{
    [JsonProperty("feed")]
    public YoulaResponseDataFeed? Feed { get; set; }
}