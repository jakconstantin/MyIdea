using Engine.Client;
using Engine.Interfaces;
using Engine.Models.ConfigurationOptions;
using MyIdea.Youla.Invariants;
using MyIdea.Youla.Models;
using MyIdea.Youla.Options;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyIdea.Youla
{
    public class YoulaHttpClient : LightWebClient, IRunParse

    {
        private readonly YoulaHttpApiClientOptions _options;
        private readonly DefaultFilterOptions _defaultFilterOptions;
        public YoulaHttpClient(YoulaHttpApiClientOptions options, DefaultFilterOptions defaultFilterOptions)
        {
            _options = options;
            _defaultFilterOptions = defaultFilterOptions;
        }       
              

        public async Task<List<IResult>> RunParse(CancellationToken stoppingToken = default)
        {
            Logger.Info("Start parser");
            var path = _options.BaseUrl + _options.GetAutoByFilterQuery;
            var body = GetRequestBody();
            string jsonBody = JsonConvert.SerializeObject(body);
            var request = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            var response = await PostAsync(path, request, stoppingToken);
            var content = await response.Content.ReadAsStringAsync(stoppingToken);
            var youlaResponse = JsonConvert.DeserializeObject<YoulaResponse>(content);

            ArgumentNullException.ThrowIfNull(youlaResponse?.Data?.Feed);

            youlaResponse.Data.Feed.Items.RemoveAll(x => x.Product == null);

            var q = from item in youlaResponse.Data.Feed.Items
                    where item.Product != null
                    select new YoulaResult() { Id = item.Product!.Id, 
                                               Url = _options.SiteUrl + item.Product.Url,
                                               Img = item.Product.Images.Count>0? item.Product.Images[0].Url :""};

            
            return q.ToList<IResult>();           
        }

        private YoulaRequest GetRequestBody()
        {
            return new YoulaRequest()
            {
                OperationName = RequestInvariants.OperationName,
                Variables = new YoulaRequestVariables()
                {
                    Sort = RequestInvariants.Sort,
                    Attributes = new List<YoulaRequestVariablesAttribute>()
                    {
                    new()
                    {
                        Slug = RequestInvariants.SlugPrice,
                        From = _defaultFilterOptions.PriceMin,
                        To = _defaultFilterOptions.PriceMax
                    },
                    new()
                    {
                        Slug = RequestInvariants.SlugCategories,
                        Value = new List<string>()
                        //Value = new List<string> { RequestInvariants.SProbegom }
                    }
                    },
                    Location = new YoulaRequestVariablesLocation()
                    {                       
                        DistanceMax = _defaultFilterOptions.DistanceMax,
                        Latitude = _defaultFilterOptions.Latitude,
                        Longitude = _defaultFilterOptions.Longitude,
                        //DistanceMax =25000,
                        //Latitude = 60.046193,
                        //Longitude = 30.44589
                        //City = RequestInvariants.CityMurino
                    },
                    Search =_defaultFilterOptions.SearchText
                },
                Extensions = new YoulaRequestExtensions()
                {
                    PersistedQuery = new YoulaRequestExtensionsPersistedQuery()
                    {
                        Version = 1,
                        Sha256Hash = "6e7275a709ca5eb1df17abfb9d5d68212ad910dd711d55446ed6fa59557e2602"

                    }
                }
            };
        }
    }
}
