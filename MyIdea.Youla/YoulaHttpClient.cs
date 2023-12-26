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
using MyIdea.Engine.Collections;
using static System.Net.WebRequestMethods;

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
            string jsonBody =  JsonConvert.SerializeObject(body);//GetTest();
            var request = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            NameValueList header = new NameValueList();

            //header.Add("Referer", "https://youla.ru/sankt-peterburg?attributes[price][from]=100000&attributes[price][to]=1000000&q=%D0%BC%D0%B0%D1%88%D0%B8%D0%BD%D0%B0");
            //header.Add("Origin","https://youla.ru");
            //header.Add("Connection", "keep-alive");
            //header.Add("Host", "api-gw.youla.io");
            //header.Add("Sec-Fetch-Dest", "empty");
            //header.Add("Sec-Fetch-Mode", "cors");
            //header.Add("User-Agent", "Mozilla/5.0 (Linux; Android 6.0; Nexus 5 Build/MRA58N) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/118.0.0.0 Mobile Safari/537.36");
            //header.Add("accept", "*/*");
            //header.Add("appId", "web/3");
            //header.Add("uid", "6501f35da5a99");

            //header.Add("sec-ch-ua", """Chromium";v="118", "Google Chrome";v="118", "Not=A?Brand";v="99""");
            //header.Add("sec-ch-ua-mobile", "?1");
            //header.Add("sec-ch-ua-platform", "Android");

            //header.Add("x-app-id", "web/3");
            //header.Add("x-offset-utc", "+03:00");
            header.Add("x-uid", "6501f35da5a99");
            //header.Add("x-youla-splits", "8a=8|8b=6|8c=0|8m=0|8v=0|8z=0|16a=0|16b=0|64a=7|64b=0|100a=44|100b=42|100c=0|100d=0|100m=0");

            //Uid: 6501f35da5a99
            /*
                         Accept-Encoding: gzip, deflate, br
            Accept-Language: ru-RU,ru;q=0.9,en-US;q=0.8,en;q=0.7
            Connection: keep-alive
            Content-Length: 482
            Host: api-gw.youla.io
            Origin: https://youla.ru
            Referer: https://youla.ru/sankt-peterburg?attributes[price][from]=100000&attributes[price][to]=1000000&q=%D0%BC%D0%B0%D1%88%D0%B8%D0%BD%D0%B0
            Sec-Fetch-Dest: empty
            Sec-Fetch-Mode: cors
            Sec-Fetch-Site: cross-site
            User-Agent: Mozilla/5.0 (Linux; Android 6.0; Nexus 5 Build/MRA58N) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/118.0.0.0 Mobile Safari/537.36

            appId: web/3
            authorization: 
            content-type: application/json
            sec-ch-ua: "Chromium";v="118", "Google Chrome";v="118", "Not=A?Brand";v="99"
            sec-ch-ua-mobile: ?1
            sec-ch-ua-platform: "Android"
            uid: 6501f35da5a99
            x-app-id: web/3
            x-offset-utc: +03:00
            x-uid: 6501f35da5a99
            x-youla-splits: 8a=8|8b=6|8c=0|8m=0|8v=0|8z=0|16a=0|16b=0|64a=7|64b=0|100a=44|100b=42|100c=0|100d=0|100m=0
            X-Uid: 6501f35da5a99
                         */



            var response = await SendAsync(path, HttpMethod.Post, header, stoppingToken, request);
            //var response = await PostAsync(path, request, stoppingToken);
            var content = await response.Content.ReadAsStringAsync(stoppingToken);
            var youlaResponse = JsonConvert.DeserializeObject<YoulaResponse>(content);

            ArgumentNullException.ThrowIfNull(youlaResponse?.Data?.Feed);

            youlaResponse.Data.Feed.Items.RemoveAll(x => x.Product == null);

            var q = from item in youlaResponse.Data.Feed.Items
                    where item.Product != null
                    select new YoulaResult() { Id = item.Product!.Id,
                        Url = _options.SiteUrl + item.Product.Url,
                        Img = item.Product.Images.Count > 0 ? item.Product.Images[0].Url : "" };

            Logger.Info("Finished parser");
            return q.ToList<IResult>();
        }

        private string GetTest()
        {
            //string s = "{\r\n    \"operationName\": \"catalogProductsBoard\",\r\n    \"variables\": {\r\n        \"sort\": \"DEFAULT\",\r\n        \"attributes\": [\r\n            {\r\n                \"slug\": \"price\",\r\n                \"value\": null,\r\n                \"from\": 100000,\r\n                \"to\": 1000000\r\n            },\r\n            {\r\n                \"slug\": \"categories\",\r\n                \"value\": [\r\n                    \"\"\r\n                ],\r\n                \"from\": null,\r\n                \"to\": null\r\n            }\r\n        ],\r\n        \"datePublished\": null,\r\n        \"location\": {\r\n            \"latitude\": null,\r\n            \"longitude\": null,\r\n            \"city\": \"576d0612d53f3d80945f8b5e\",\r\n            \"distanceMax\": null\r\n        },\r\n        \"search\": \"блокнот\",\r\n        \"cursor\": \"\"\r\n    },\r\n    \"extensions\": {\r\n        \"persistedQuery\": {\r\n            \"version\": 1,\r\n            \"sha256Hash\": \"6e7275a709ca5eb1df17abfb9d5d68212ad910dd711d55446ed6fa59557e2602\"\r\n        }\r\n    }\r\n}";
            //string s = "{\r\n    \"operationName\": \"catalogProductsBoard\",\r\n    \"variables\": {\r\n        \"sort\": \"DEFAULT\",\r\n        \"attributes\": [\r\n            {\r\n                \"slug\": \"categories\",\r\n                \"value\": [\r\n                    \"\"\r\n                ],\r\n                \"from\": null,\r\n                \"to\": null\r\n            }\r\n        ],\r\n        \"datePublished\": null,\r\n        \"location\": {\r\n            \"latitude\": null,\r\n            \"longitude\": null,\r\n            \"city\": \"576d0612d53f3d80945f8b5e\",\r\n            \"distanceMax\": null\r\n        },\r\n        \"search\": \"блокнот\",\r\n        \"cursor\": \"\"\r\n    },\r\n    \"extensions\": {\r\n        \"persistedQuery\": {\r\n            \"version\": 1,\r\n            \"sha256Hash\": \"6e7275a709ca5eb1df17abfb9d5d68212ad910dd711d55446ed6fa59557e2602\"\r\n        }\r\n    }\r\n}";
            string s = "{\r\n  \"operationName\": \"catalogProductsBoard\",\r\n  \"variables\": {\r\n    \"sort\": \"DEFAULT\",\r\n    \"attributes\": [\r\n      {\r\n        \"slug\": \"price\",\r\n        \"value\": null,\r\n        \"from\": 100000,\r\n        \"to\": 1000000\r\n      },\r\n      {\r\n        \"slug\": \"categories\",\r\n        \"value\": [\r\n          \"\"\r\n        ],\r\n        \"from\": null,\r\n        \"to\": null\r\n      }\r\n    ],\r\n    \"datePublished\": null,\r\n    \"location\": {\r\n      \"latitude\": null,\r\n      \"longitude\": null,\r\n      \"city\": \"576d0612d53f3d80945f8b5e\",\r\n      \"distanceMax\": null\r\n    },\r\n    \"search\": \"машина\",\r\n    \"cursor\": \"\"\r\n  },\r\n  \"extensions\": {\r\n    \"persistedQuery\": {\r\n      \"version\": 1,\r\n      \"sha256Hash\": \"6e7275a709ca5eb1df17abfb9d5d68212ad910dd711d55446ed6fa59557e2602\"\r\n    }\r\n  }\r\n}";
            return s;
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
                        Value = new List<string>(){""}
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
