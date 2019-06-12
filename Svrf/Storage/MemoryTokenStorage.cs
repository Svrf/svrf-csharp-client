using Svrf.Models;

namespace Svrf.Storage
{
    internal class MemoryTokenStorage : ITokenStorage
    {
        private AppTokenInfo _appTokenInfo;

        public AppTokenInfo Get()
        {
            return _appTokenInfo;
        }

        public void Set(AppTokenInfo appTokenInfo)
        {
            _appTokenInfo = appTokenInfo;
        }

        public void Clear()
        {
            _appTokenInfo = null;
        }
    }
}
