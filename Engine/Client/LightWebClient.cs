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


        protected virtual async Task<HttpResponseMessage> SendAsync(string path, HttpMethod method, HttpContent? content = null)
        {
            var request = new HttpRequestMessage(method, path)
            {
                Content = content,
            };

            return await _httpClient.SendAsync(request);
        }

        protected virtual async Task<HttpResponseMessage> PostAsync(string? requestUri, HttpContent? content, CancellationToken cancellationToken)
        {
            return await _httpClient.PostAsync(requestUri, content, cancellationToken);
        }
    }
}
