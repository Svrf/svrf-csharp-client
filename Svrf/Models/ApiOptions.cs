using Svrf.Storage;

namespace Svrf.Models
{
    public class ApiOptions
    {
        public bool IsManualAuthentication { get; set; } = false;

        public ITokenStorage Storage { get; set; }
    }
}
