using System;
using System.Net;
using System.Threading.Tasks;
using Svrf.Exceptions;
using Svrf.Http;
using Svrf.Models.Http;
using Svrf.Services;

namespace Svrf.Api
{
    internal class AuthApi
    {
        private readonly IHttpClient _httpClient;
        private readonly TokenService _tokenService;
        private readonly string _apiKey;

        private Task<AuthResponse> AuthTask;

        internal AuthApi(IHttpClient httpClient, TokenService tokenService, string apiKey)
        {
            _httpClient = httpClient;
            _tokenService = tokenService;
            _apiKey = apiKey;
        }

        public async Task AuthenticateAsync()
        {
            if (_tokenService.IsTokenValid)
            {
                return;
            }

            if (string.IsNullOrEmpty(_apiKey))
            {
                throw new ArgumentException("Api Key should be provided for authentication", nameof(_apiKey));
            }

            var requestBody = new AuthRequestBody() { ApiKey = _apiKey };

            if (AuthTask == null)
            {
                AuthTask = _httpClient.PostAsync<AuthResponse>("app/authenticate", requestBody);
            }

            try
            {
                var response = await AuthTask;
                _tokenService.SetAppTokenInfo(response.Token, response.ExpiresIn);
            }
            catch (HttpException ex)
            {
                switch (ex.Code)
                {
                    case HttpStatusCode.NotFound:
                        throw new ApiKeyNotFoundException(ex.Message);
                }
            }
            finally
            {
                AuthTask = null;
            }
        }
    }
}
