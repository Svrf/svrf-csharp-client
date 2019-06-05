using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Svrf.Storage;
using Svrf.Http;
using Svrf.Api;
using Svrf.Models;
using Svrf.Services;

[assembly: InternalsVisibleTo("Svrf.Tests.Integration")]
[assembly: InternalsVisibleTo("Svrf.Tests.Unit")]

namespace Svrf
{
    /// <summary>
    /// Main class that represents Svrf API.
    /// </summary>
    public class SvrfClient
    {
        private AuthApi Auth { get; }

        /// <summary>
        /// MediaApi instance that represents media-related endpoints.
        /// </summary>
        public MediaApi Media { get; }

        /// <summary>Creates SvrfClient instance with provided API key and options.</summary>
        /// <param name="apiKey">Your API key.</param>
        /// <param name="options">Additional options.</param>
        public SvrfClient(string apiKey, ApiOptions options = null)
        {
            JsonConvert.DefaultSettings = () =>
            {
                var settings = new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    Converters = new List<JsonConverter> { new StringEnumConverter() }
                };
                return settings;
            };

            var isManualAuthentication = options?.IsManualAuthentication ?? false;
            var tokenStorage = options?.Storage ?? new MemoryTokenStorage();
            var tokenService = new TokenService(tokenStorage, new DateTimeProvider());
            var httpClient = new BaseHttpClient(new HttpClient());

            Auth = new AuthApi(httpClient, tokenService, apiKey);

            var appTokenHttpClient = new AppTokenHttpClient(Auth, tokenService, new HttpClient());

            Media = new MediaApi(appTokenHttpClient);

            if (!isManualAuthentication)
            {
                Task.Run(AuthenticateAsync);
            }
        }

        /// <summary>
        /// Authenticates your app: retrieves token and saves it or takes it from the storage.
        /// You should call it only if you passed the isManualAuthentication option.
        /// </summary>
        public async Task AuthenticateAsync()
        {
            await Auth.AuthenticateAsync();
        }
    }
}
