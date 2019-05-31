using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Svrf.Exceptions;
using Svrf.Services;

namespace Svrf.Http
{
    internal class BaseHttpClient : IHttpClient
    {
        protected HttpClient HttpClient { get; }

        internal BaseHttpClient(HttpClient httpClient)
        {
            HttpClient = httpClient;
            HttpClient.BaseAddress = new Uri("https://api.svrf.com/v1/");
        }

        public virtual async Task<T> GetAsync<T>(string uri, IDictionary<string, object> requestParams = null)
        {
            var formattedUri = FormatUri(uri, requestParams);

            var response = await HttpClient.GetAsync(formattedUri);
            var result = await HandleResponse<T>(response);
            return result;
        }

        public virtual async Task<T> PostAsync<T>(string uri, object body)
        {
            var bodyString = JsonConvert.SerializeObject(body);
            var response = await HttpClient.PostAsync(uri, new StringContent(bodyString, Encoding.UTF8, "application/json"));

            var result = await HandleResponse<T>(response);
            return result;
        }

        private string FormatUri(string uri, IDictionary<string, object> requestParams)
        {
            if (requestParams == null) return uri;

            var queryString = string.Join("&", QueryService.Build(requestParams));

            return $"{uri}?{queryString}";
        }

        private async Task<T> HandleResponse<T>(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpException(response.StatusCode);
            }

            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(responseString);
            return result;
        }
    }
}
