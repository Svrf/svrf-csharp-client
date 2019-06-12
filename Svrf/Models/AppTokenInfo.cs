using System;

namespace Svrf.Models
{
    /// <summary>
    /// App token information that should be stored after authentication in the token storage.
    /// </summary>
    public class AppTokenInfo
    {
        /// <summary>
        /// App token that should be stored.
        /// </summary>
        public string AppToken { get; set; }

        /// <summary>
        /// DateTime when the token expires.
        /// </summary>
        public DateTime ExpirationTime { get; set; }

        public AppTokenInfo(string appToken, DateTime expirationTime)
        {
            AppToken = appToken;
            ExpirationTime = expirationTime;
        }

        public bool Equals(AppTokenInfo other)
        {
            return string.Equals(AppToken, other.AppToken) && ExpirationTime.Equals(other.ExpirationTime);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((AppToken != null ? AppToken.GetHashCode() : 0) * 397) ^ ExpirationTime.GetHashCode();
            }
        }
    }
}
