using Newtonsoft.Json;

namespace Idea.Youla.Models;

public class YoulaResponse
{
    [JsonProperty("data")]
    public YoulaResponseData? Data { get; set; }
}