using Newtonsoft.Json;

namespace MyIdea.Youla.Models;

public class YoulaResponseDataFeedItemProductPrice
{
    [JsonProperty("realPrice")]
    public YoulaResponseDataFeedItemProductPriceRealPrice RealPrice { get; set; }
}