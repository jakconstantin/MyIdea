using Newtonsoft.Json;

namespace Idea.Youla.Models;

public class YoulaResponseDataFeedItemProductPrice
{
    [JsonProperty("realPrice")]
    public YoulaResponseDataFeedItemProductPriceRealPrice RealPrice { get; set; }
}