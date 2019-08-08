using System.Runtime.CompilerServices;
using Svrf.Models;
using Svrf.Services.Interfaces;
using Svrf.Storage;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace Svrf.Services
{
    internal class TokenService : ITokenService
    {
        private readonly ITokenStorage _tokenStorage;
        private readonly IDateTimeService _dateTimeProvider;

        public bool IsTokenValid
        {
            get
            {
                var appTokenInfo = _tokenStorage.Get();

                if (appTokenInfo == null)
                {
                    return false;
                }

                var isTokenValid = !string.IsNullOrEmpty(appTokenInfo.AppToken)
                    && (DateTimeService.Compare(appTokenInfo.ExpirationTime, _dateTimeProvider.Now) > 0);

                return isTokenValid;
            }
        }

        public TokenService(ITokenStorage tokenStorage, IDateTimeService dateTimeProvider)
        {
            _tokenStorage = tokenStorage;
            _dateTimeProvider = dateTimeProvider;
        }

        public string GetAppToken() => _tokenStorage.Get().AppToken;

        public void SetAppTokenInfo(string token, int expiresIn)
        {
            var expirationTime = _dateTimeProvider.Now.AddSeconds(expiresIn);
            var appTokenInfo = new AppTokenInfo(token, expirationTime);

            _tokenStorage.Set(appTokenInfo);
        }

        public void ClearAppTokenInfo()
        {
            _tokenStorage.Clear();
        }

        public AppTokenInfo GetAppTokenInfo() => _tokenStorage.Get();
    }
}
