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

        public async Task<SingleMediaResponse> GetByIdAsync(int id)
        {
            return await GetByIdAsync(id.ToString());
        }

        public async Task<SingleMediaResponse> GetByIdAsync(string id)
        {
            var response = await MakeRequestAsync<SingleMediaResponse>($"vr/{id}");
            return response;
        }

        public async Task<MultipleMediaResponse> GetTrendingAsync(HttpRequestParams httpRequestParams = null)
        {
            var requestParams = httpRequestParams?.ToDictionary();
            var response = await MakeRequestAsync<MultipleMediaResponse>("vr/trending", requestParams);
            return response;
        }

        public async Task<MultipleMediaResponse> SearchAsync(string query, HttpRequestParams httpRequestParams = null)
        {
            var requestParams = httpRequestParams == null
                ? new Dictionary<string, object>()
                : httpRequestParams.ToDictionary();
            requestParams["q"] = query;

            var response = await MakeRequestAsync<MultipleMediaResponse>("vr/search", requestParams);
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
