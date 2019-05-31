using Svrf.Models;

namespace Svrf.Storage
{
    internal class MemoryTokenStorage : ITokenStorage
    {
        private AppTokenInfo AppTokenInfo { get; set; }

        public AppTokenInfo Get()
        {
            return AppTokenInfo;
        }

        public void Set(AppTokenInfo appTokenInfo)
        {
            AppTokenInfo = appTokenInfo;
        }

        public void Clear()
        {
            AppTokenInfo = null;
        }
    }
}
