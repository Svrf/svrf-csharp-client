﻿using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Svrf.Api;
using Svrf.Services;

namespace Svrf.Http
{
    internal class AppTokenHttpClient : BaseHttpClient
    {
        private AuthApi AuthApi { get; }
        private TokenService TokenService { get; }

        internal AppTokenHttpClient(AuthApi authApi, TokenService tokenService, HttpClient httpClient) : base(httpClient)
        {
            AuthApi = authApi;
            TokenService = tokenService;
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
            await AuthApi.AuthenticateAsync();

            var appToken = TokenService.GetAppToken();

            if (HttpClient.DefaultRequestHeaders.Contains("x-app-token"))
            {
                HttpClient.DefaultRequestHeaders.Remove("x-app-token");
            }

            HttpClient.DefaultRequestHeaders.Add("x-app-token", appToken);
        }
    }
}
