using Engine.Client;

namespace MyIdea.Youla.Options;

public class YoulaHttpApiClientOptions : HttpApiClientOptions
{
    public string SiteUrl  { get; set; }
    
    public string GetAutoByFilterQuery { get; set; }
}