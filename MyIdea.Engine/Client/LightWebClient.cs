using MyIdea.Engine.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Client
{
    public abstract class LightWebClient
    {
        private readonly HttpClient _httpClient;

        protected LightWebClient()
        {
            _httpClient = new HttpClient();
        }


        protected virtual async Task<HttpResponseMessage> SendAsync(string path, HttpMethod method, NameValueList header, CancellationToken cancellationToken, HttpContent? content = null )
        {
            var request = new HttpRequestMessage(method, path)
            {
                Content = content,   
            };

            if (header != null)
            {
                foreach (var headerValue in header) 
                {
                    request.Headers.Add(headerValue.Key, headerValue.Value);
                }
            }            

            return await _httpClient.SendAsync(request, cancellationToken);
        }

        protected virtual async Task<HttpResponseMessage> PostAsync(string? requestUri, HttpContent? content, CancellationToken cancellationToken)
        {
            return await _httpClient.PostAsync(requestUri, content, cancellationToken);
        }
    }
}
