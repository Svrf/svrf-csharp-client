using System.Runtime.CompilerServices;
using Svrf.Models;
using Svrf.Storage;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace Svrf.Services
{
    internal class TokenService
    {
        private ITokenStorage TokenStorage { get; }
        private DateTimeProvider DateTimeProvider { get; }

        public virtual bool IsTokenValid
        {
            get
            {
                var appTokenInfo = TokenStorage.Get();

                if (appTokenInfo == null)
                {
                    return false;
                }

                var isTokenValid = !string.IsNullOrEmpty(appTokenInfo.AppToken)
                    && (DateTimeProvider.Compare(appTokenInfo.ExpirationTime, DateTimeProvider.Now) > 0);

                return isTokenValid;
            }
        }

        public TokenService(ITokenStorage tokenStorage, DateTimeProvider dateTimeProvider)
        {
            TokenStorage = tokenStorage;
            DateTimeProvider = dateTimeProvider;
        }

        public string GetAppToken() => TokenStorage.Get().AppToken;

        public void SetAppTokenInfo(string token, int expiresIn)
        {
            var expirationTime = DateTimeProvider.Now.AddSeconds(expiresIn);
            var appTokenInfo = new AppTokenInfo(token, expirationTime);

            TokenStorage.Set(appTokenInfo);
        }

        public void ClearAppTokenInfo()
        {
            TokenStorage.Clear();
        }

        public AppTokenInfo GetAppTokenInfo() => TokenStorage.Get();
    }
}
