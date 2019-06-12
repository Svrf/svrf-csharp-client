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

        private readonly object _authRequestLock = new object();
        private Task<AuthResponse> _authTask;

        internal AuthApi(IHttpClient httpClient, TokenService tokenService, string apiKey)
        {
            _httpClient = httpClient;
            _tokenService = tokenService;
            _apiKey = apiKey;
        }

        internal async Task AuthenticateAsync()
        {
            if (_tokenService.IsTokenValid)
            {
                return;
            }

            if (string.IsNullOrEmpty(_apiKey))
            {
                throw new ArgumentException("Api Key should be provided for authentication", nameof(_apiKey));
            }

            var requestBody = new AuthRequestBody { ApiKey = _apiKey };

            // Since we have to call it with Task.Run in the SvrfClient, it can be accessed from
            // multiple threads. Therefore, two threads can enter this code before _httpClient.PostAsync
            // is completed. Locking is needed to avoid this kind of race condition in this method.
            lock (_authRequestLock)
            {
                if (_authTask == null)
                {
                    _authTask = _httpClient.PostAsync<AuthResponse>("app/authenticate", requestBody);
                }
            }

            try
            {
                var response = await _authTask;
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
                _authTask = null;
            }
        }
    }
}
