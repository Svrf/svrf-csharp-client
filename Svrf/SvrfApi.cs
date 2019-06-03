using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Svrf.Storage;
using Svrf.Http;
using Svrf.Api;
using Svrf.Models;
using Svrf.Services;

[assembly: InternalsVisibleTo("Svrf.Tests.Unit")]

namespace Svrf
{
    public class SvrfClient
    {
        private AuthApi AuthApi { get; }
        public MediaApi MediaApi { get; }

        public SvrfClient(string apiKey, ApiOptions options = null)
        {
            JsonConvert.DefaultSettings = () =>
            {
                var settings = new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };
                return settings;
            };

            var isManualAuthentication = options?.IsManualAuthentication ?? false;
            var tokenStorage = options?.Storage ?? new MemoryTokenStorage();
            var tokenService = new TokenService(tokenStorage, new DateTimeProvider());
            var httpClient = new BaseHttpClient(new HttpClient());

            AuthApi = new AuthApi(httpClient, tokenService, apiKey);

            var appTokenHttpClient = new AppTokenHttpClient(AuthApi, tokenService, new HttpClient());

            MediaApi = new MediaApi(appTokenHttpClient);

            if (!isManualAuthentication)
            {
                Task.Run(Authenticate);
            }
        }

        public async Task Authenticate()
        {
            await AuthApi.AuthenticateAsync();
        }
    }
}
