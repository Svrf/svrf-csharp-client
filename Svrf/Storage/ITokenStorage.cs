using Svrf.Models;

namespace Svrf.Storage
{
    /// <summary>
    /// Interface for implementing custom token storage.
    /// </summary>
    public interface ITokenStorage
    {
        /// <summary>
        /// Get token info from the storage.
        /// </summary>
        /// <returns>Token info.</returns>
        AppTokenInfo Get();

        /// <summary>
        /// Save token info to the storage.
        /// </summary>
        /// <param name="appTokenInfo">Token info.</param>
        void Set(AppTokenInfo appTokenInfo);

        /// <summary>
        /// Clear the storage.
        /// </summary>
        void Clear();
    }
}
