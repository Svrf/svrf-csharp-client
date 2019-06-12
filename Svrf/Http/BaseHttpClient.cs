using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Svrf.Exceptions;
using Svrf.Services;
using System.Net;
using Svrf.Models.Http;

namespace Svrf.Http
{
    internal class BaseHttpClient : IHttpClient
    {
        protected readonly HttpClient _httpClient;

        internal BaseHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://api.svrf.com/v1/");
        }

        public virtual async Task<T> GetAsync<T>(string uri, IDictionary<string, object> requestParams = null)
        {
            var formattedUri = FormatUri(uri, requestParams);

            var response = await _httpClient.GetAsync(formattedUri);
            var result = await HandleResponse<T>(response);
            return result;
        }

        public virtual async Task<T> PostAsync<T>(string uri, object body)
        {
            var bodyString = JsonConvert.SerializeObject(body);
            var httpContent = new StringContent(bodyString, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(uri, httpContent);

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
            var responseString = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(responseString);

                // Common errors for all endpoints.
                switch (response.StatusCode)
                {
                    case HttpStatusCode.Forbidden:
                        throw new UnauthorizedException(errorResponse.Message);
                    case (HttpStatusCode)429:
                        throw new TooManyRequestsException(errorResponse.Message);
                }

                throw new HttpException(errorResponse.Message, response.StatusCode);
            }

            var result = JsonConvert.DeserializeObject<T>(responseString);
            return result;
        }
    }
}
