using Svrf.Storage;

namespace Svrf.Models
{
    public class ApiOptions
    {
        /// <summary>
        /// Pass this option if you want to call the AuthenticateAsync method manually (for example while user IDLE).
        /// </summary>
        public bool IsManualAuthentication { get; set; } = false;

        /// <summary>
        /// Custom app token storage.
        /// </summary>
        public ITokenStorage Storage { get; set; }
    }
}
