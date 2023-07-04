using Newtonsoft.Json;

namespace Idea.Youla.Models;

public class YoulaResponseDataFeedItemProductPriceRealPrice
{
    [JsonProperty("price")]
    public int Price { get; set; }
}