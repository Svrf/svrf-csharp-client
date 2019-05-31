using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Svrf.Exceptions;
using Svrf.Http;
using Svrf.Models.Http;
using Svrf.Services;

namespace Svrf.Api
{
    internal class AuthApi
    {
        private IHttpClient HttpClient { get; }
        private TokenService TokenService { get; }
        private string ApiKey { get; }

        private Task<AuthResponse> AuthTask { get; set; }

        internal AuthApi(IHttpClient httpClient, TokenService tokenService, string apiKey)
        {
            HttpClient = httpClient;
            TokenService = tokenService;
            ApiKey = apiKey;
        }

        public async Task AuthenticateAsync()
        {
            if (TokenService.IsTokenValid)
            {
                return;
            }

            if (string.IsNullOrEmpty(ApiKey))
            {
                throw new ArgumentException("Api Key should be provided for authentication", nameof(ApiKey));
            }

            var requestBody = new AuthRequestBody() { ApiKey = ApiKey };

            if (AuthTask == null)
            {
                AuthTask = HttpClient.PostAsync<AuthResponse>("app/authenticate", requestBody);
            }

            try
            {
                var response = await AuthTask;
                TokenService.SetAppTokenInfo(response.Token, response.ExpiresIn);
            }
            catch (HttpException ex)
            {
                switch (ex.Code)
                {
                    case HttpStatusCode.NotFound:
                        throw new ApiKeyIsNotFoundException();
                }
            }
            finally
            {
                AuthTask = null;
            }


        }
    }
}
