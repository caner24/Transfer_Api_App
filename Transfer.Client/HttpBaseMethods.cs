using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Transfer.Client
{
    public abstract class HttpBaseMethods
    {
        private readonly HttpClient _httpClient;

        public HttpBaseMethods(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T> Get<T>(string uri, CancellationToken cancellationToken)
        {
            return await SendRequest<T>(HttpMethod.Get, uri, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        public async Task<T> Get<T>(string uri, Action<HttpResponseHeaders> headerFunc, CancellationToken cancellationToken)
        {
            return await SendRequest<T>(HttpMethod.Get, uri, null, headerFunc, null, cancellationToken).ConfigureAwait(false);
        }

        public async Task<T> Get<T>(string uri, Action<HttpResponseHeaders> headerFunc, Dictionary<string, string> headers, CancellationToken cancellationToken)
        {
            return await SendRequest<T>(HttpMethod.Get, uri, null, headerFunc, headers, cancellationToken).ConfigureAwait(false);
        }

        public async Task<T> Post<T>(string uri, object request, CancellationToken cancellationToken)
        {
            return await SendRequest<T>(HttpMethod.Post, uri, request, null, null, cancellationToken).ConfigureAwait(false);
        }

        public async Task<T> Post<T>(string uri, object request, Dictionary<string, string> headers, CancellationToken cancellationToken)
        {
            return await SendRequest<T>(HttpMethod.Post, uri, request, null, headers, cancellationToken).ConfigureAwait(false);
        }

        public async Task<T> Post<T>(string uri, object request, Action<HttpResponseHeaders> headerFunc, Dictionary<string, string> headers, CancellationToken cancellationToken)
        {
            return await SendRequest<T>(HttpMethod.Post, uri, request, headerFunc, headers, cancellationToken).ConfigureAwait(false);
        }

        public async Task<T> Put<T>(string uri, object request, CancellationToken cancellationToken)
        {
            return await SendRequest<T>(HttpMethod.Put, uri, request, null, null, cancellationToken).ConfigureAwait(false);
        }

        public async Task<T> Put<T>(string uri, object request, Dictionary<string, string> headers, CancellationToken cancellationToken)
        {
            return await SendRequest<T>(HttpMethod.Put, uri, request, null, headers, cancellationToken).ConfigureAwait(false);
        }

        public async Task<T> Patch<T>(string uri, object request, CancellationToken cancellationToken)
        {
            return await SendRequest<T>(HttpMethod.Patch, uri, request, null, null, cancellationToken).ConfigureAwait(false);
        }

        public async Task<T> Patch<T>(string uri, object request, Dictionary<string, string> headers, CancellationToken cancellationToken)
        {
            return await SendRequest<T>(HttpMethod.Patch, uri, request, null, headers, cancellationToken).ConfigureAwait(false);
        }

        public async Task<T> Delete<T>(string uri, CancellationToken cancellationToken)
        {
            return await SendRequest<T>(HttpMethod.Delete, uri, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        public async Task<T> Delete<T>(string uri, Dictionary<string, string> headers, CancellationToken cancellationToken)
        {
            return await SendRequest<T>(HttpMethod.Delete, uri, null, null, headers, cancellationToken).ConfigureAwait(false);
        }

        private async Task<T> SendRequest<T>(HttpMethod method, string uri, object? body, Action<HttpResponseHeaders>? headerFunc, Dictionary<string, string>? headers, CancellationToken cancellationToken)
        {
            var httpRequest = new HttpRequestMessage
            {
                Method = method,
                RequestUri = new Uri($"{_httpClient.BaseAddress}{uri}")
            };

            if (headers != null && headers.Count > 0)
            {
                foreach (var header in headers)
                {
                    var exist = httpRequest.Headers.Contains(header.Key);
                    if (exist)
                    {
                        httpRequest.Headers.Remove(header.Key);
                    }
                    httpRequest.Headers.Add(header.Key, header.Value);
                }
            }

            if (body != null)
            {
                string serializedRequest = JsonConvert.SerializeObject(body);
                httpRequest.Content = new StringContent(serializedRequest, Encoding.UTF8, "application/json");
            }

            var httpResponseMessage = await _httpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);

            string json;
            if (headerFunc == null)
                json = await ResponseExtensions.ProcessResponse(httpResponseMessage).ConfigureAwait(false);
            else
                json = await ResponseExtensions.ProcessResponse(httpResponseMessage, headerFunc).ConfigureAwait(false);

            return JsonConvert.DeserializeObject<T>(json);
        }

    }
}
