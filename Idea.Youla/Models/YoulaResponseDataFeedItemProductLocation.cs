﻿using Newtonsoft.Json;

namespace Idea.Youla.Models;

public class YoulaResponseDataFeedItemProductLocation
{
    [JsonProperty("cityName")]
    public string CityName { get; set; }

    [JsonProperty("city")]
    public string City { get; set; }

    [JsonProperty("addressText")]
    public string AddressText { get; set; }
}