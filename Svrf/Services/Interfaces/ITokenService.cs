using Svrf.Models;

namespace Svrf.Services.Interfaces
{
    internal interface ITokenService
    {
        bool IsTokenValid { get; }
        string GetAppToken();
        void ClearAppTokenInfo();
        void SetAppTokenInfo(string token, int expiresIn);
        AppTokenInfo GetAppTokenInfo();
    }
}
