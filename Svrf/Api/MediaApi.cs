using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Svrf.Exceptions;
using Svrf.Http;
using Svrf.Models.Http;

namespace Svrf.Api
{
    /// <summary>
    /// Represents media-related endpoints.
    /// </summary>
    public class MediaApi
    {
        private readonly IHttpClient _httpClient;

        internal MediaApi(IHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Gets media by provided id.
        /// </summary>
        /// <param name="id">Media ID.</param>
        /// <returns>Response with single media.</returns>
        public async Task<SingleMediaResponse> GetByIdAsync(int id)
        {
            return await GetByIdAsync(id.ToString());
        }

        /// <summary>
        /// Gets media by provided id.
        /// </summary>
        /// <param name="id">Media ID.</param>
        /// <returns>Response with single media.</returns>
        public async Task<SingleMediaResponse> GetByIdAsync(string id)
        {
            var response = await MakeRequestAsync<SingleMediaResponse>($"vr/{id}");
            return response;
        }

        /// <summary>
        /// Gets trending media.
        /// </summary>
        /// <param name="mediaRequestParams">Request params.</param>
        /// <returns>Response with trending media and pagination info.</returns>
        public async Task<MultipleMediaResponse> GetTrendingAsync(MediaRequestParams mediaRequestParams = null)
        {
            var requestParams = mediaRequestParams?.ToDictionary();
            var response = await MakeRequestAsync<MultipleMediaResponse>("vr/trending", requestParams);
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="mediaRequestParams"></param>
        /// <returns>Response with found media and pagination info.</returns>
        public async Task<MultipleMediaResponse> SearchAsync(string query, MediaRequestParams mediaRequestParams = null)
        {
            var requestParams = mediaRequestParams == null
                ? new Dictionary<string, object>()
                : mediaRequestParams.ToDictionary();
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
