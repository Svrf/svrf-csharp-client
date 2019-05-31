using System;

namespace Svrf.Models
{
    public class AppTokenInfo
    {
        public string AppToken { get; set; }
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
