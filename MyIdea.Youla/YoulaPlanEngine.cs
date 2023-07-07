using Engine;
using Engine.Interfaces;
using Engine.Models.ConfigurationOptions;
using Engine.PlanEngine;
using Idea.Youla.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idea.Youla
{
    public class YoulaPlanEngine: PlanEngineBase
    {
        private Plan _plan;
        YoulaHttpClient _httpClient;
        public YoulaPlanEngine(Plan plan)
        {
            YoulaHttpApiClientOptions options = new YoulaHttpApiClientOptions() 
            { 
                BaseUrl = "https://api-gw.youla.io", 
                SiteUrl = "https://youla.ru", 
                GetAutoByFilterQuery = "/federation/graphql" 
            };
            DefaultFilterOptions defaultFilterOptions = new DefaultFilterOptions();
            defaultFilterOptions.PriceMin = plan.PriceMin*100;
            defaultFilterOptions.PriceMax = plan.PriceMax*100;
            defaultFilterOptions.SearchText = plan.SearchText;

            //"BaseUrl": "https://api-gw.youla.io",
            //"SiteUrl": "https://youla.ru",
            //"GetAutoByFilterQuery": "/federation/graphql"
            _plan = plan;
            _httpClient = new YoulaHttpClient(options, defaultFilterOptions);
        }

        public override async Task<List<IResult>> RunParse(CancellationToken stoppingToken = default)
        {
            var result = await _httpClient.RunParse(stoppingToken);
            return result;
        }
    }
}
