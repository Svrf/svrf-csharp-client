using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Svrf.Exceptions;
using Svrf.Http;
using Svrf.Models.Http;

namespace Svrf.Api
{
    internal class MediaApi
    {
        private IHttpClient HttpClient { get; }

        internal MediaApi(IHttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<SingleMediaApiResponse> GetByIdAsync(int id)
        {
            return await GetByIdAsync(id.ToString());
        }

        public async Task<SingleMediaApiResponse> GetByIdAsync(string id)
        {
            var response = await MakeRequestAsync<SingleMediaApiResponse>($"vr/{id}");
            return response;
        }

        public async Task<MultipleMediaApiResponse> GetTrendingAsync(HttpRequestParams httpRequestParams = null)
        {
            var requestParams = httpRequestParams?.ToDictionary();
            var response = await MakeRequestAsync<MultipleMediaApiResponse>("vr/trending", requestParams);
            return response;
        }

        public async Task<MultipleMediaApiResponse> SearchAsync(string query, HttpRequestParams httpRequestParams = null)
        {
            var requestParams = httpRequestParams == null
                ? new Dictionary<string, object>()
                : httpRequestParams.ToDictionary();
            requestParams["q"] = query;

            var response = await MakeRequestAsync<MultipleMediaApiResponse>("vr/search", requestParams);
            return response;
        }

        private async Task<T> MakeRequestAsync<T>(string uri, IDictionary<string, object> requestParams = null)
        {
            var response = await HttpClient.GetAsync(uri, requestParams);

            switch (response.StatusCode)
            {
                case HttpStatusCode.NotFound:
                    throw new MediaNotFoundException("Requested media was not found");
                case HttpStatusCode.Unauthorized:
                    throw new UnauthorizedException("Unauthorized request");
            }

            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseString);
        }
    }
}
