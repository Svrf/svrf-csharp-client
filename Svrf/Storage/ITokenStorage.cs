using Svrf.Models;

namespace Svrf.Storage
{
    public interface ITokenStorage
    {
        AppTokenInfo Get();
        void Set(AppTokenInfo appTokenInfo);
        void Clear();
    }
}
