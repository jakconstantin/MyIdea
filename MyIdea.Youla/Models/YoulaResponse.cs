﻿using Newtonsoft.Json;

namespace MyIdea.Youla.Models;

public class YoulaResponse
{
    [JsonProperty("data")]
    public YoulaResponseData? Data { get; set; }
}