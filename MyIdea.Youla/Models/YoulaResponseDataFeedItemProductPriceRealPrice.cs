using Newtonsoft.Json;

namespace MyIdea.Youla.Models;

public class YoulaResponseDataFeedItemProductPriceRealPrice
{
    [JsonProperty("price")]
    public int Price { get; set; }
}