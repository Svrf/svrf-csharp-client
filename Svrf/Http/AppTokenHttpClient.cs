using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Svrf.Api.Interfaces;
using Svrf.Services.Interfaces;

namespace Svrf.Http
{
    internal class AppTokenHttpClient : BaseHttpClient
    {
        private readonly IAuthApi _authApi;
        private readonly ITokenService _tokenService;

        internal AppTokenHttpClient(IAuthApi authApi, ITokenService tokenService, HttpClient httpClient, IQueryService queryService)
            : base(httpClient, queryService)
        {
            _authApi = authApi;
            _tokenService = tokenService;
        }

        public override async Task<T> GetAsync<T>(string uri, IDictionary<string, object> requestParams = null)
        {
            await SetAppTokenHeader();

            return await base.GetAsync<T>(uri, requestParams);
        }

        public override async Task<T> PostAsync<T>(string uri, object body)
        {
            await SetAppTokenHeader();

            return await base.PostAsync<T>(uri, body);
        }

        private async Task SetAppTokenHeader()
        {
            await _authApi.AuthenticateAsync();

            var appToken = _tokenService.GetAppToken();

            if (_httpClient.DefaultRequestHeaders.Contains("x-app-token"))
            {
                _httpClient.DefaultRequestHeaders.Remove("x-app-token");
            }

            _httpClient.DefaultRequestHeaders.Add("x-app-token", appToken);
        }
    }
}
