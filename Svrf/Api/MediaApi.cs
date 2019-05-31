using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Svrf.Exceptions;
using Svrf.Http;
using Svrf.Models.Http;

namespace Svrf.Api
{
    public class MediaApi
    {
        private readonly IHttpClient _httpClient;

        internal MediaApi(IHttpClient httpClient)
        {
            _httpClient = httpClient;
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
            try
            {
                var response = await _httpClient.GetAsync<T>(uri, requestParams);
                return response;
            }
            catch(HttpException ex)
            {
                switch (ex.Code)
                {
                    case HttpStatusCode.NotFound:
                        throw new MediaNotFoundException(ex.Message);
                    default:
                        throw new ServerErrorException(ex.Message);
                }
            }
        }
    }
}
